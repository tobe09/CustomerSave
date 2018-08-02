using CustomerSave.Common;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serenity;
using Serenity.Services;
using System;
using System.Threading.Tasks;

namespace CustomerSave.Membership.Pages
{

    [Route("Account/[action]")]
    public partial class AccountController : Controller
    {
        public static bool UseAdminLTELoginBox = false;

        [HttpGet]
        public ActionResult Login(string activated)
        {
            ViewData["Activated"] = activated;
            ViewData["HideLeftNavigation"] = true;

            if (UseAdminLTELoginBox)
                return View(MVC.Views.Membership.Account.AccountLogin_AdminLTE);
            else
                return View(MVC.Views.Membership.Account.AccountLogin);
        }

        [HttpGet]
        public ActionResult AccessDenied(string returnURL)
        {
            ViewData["HideLeftNavigation"] = !Authorization.IsLoggedIn;

            return View(MVC.Views.Errors.AccessDenied, (object)returnURL);
        }

        [HttpPost, JsonFilter]
        public Result<ServiceResponse> Login(LoginRequest request)
        {
            return this.ExecuteMethod(() =>
            {
                request.CheckNotNull();

                if (string.IsNullOrEmpty(request.Username))
                    throw new ArgumentNullException("username");

                var username = request.Username;
                if (WebSecurityHelper.Authenticate(ref username, request.Password, false))
                {
                    Membership.User.SaveUserToSession(username, Request.HttpContext).Wait();  //to ensure that the response waits for the request's session
                    return new ServiceResponse();
                }

                throw new ValidationError("AuthenticationError", Texts.Validation.AuthenticationError);
            });
        }

        private ActionResult Error(string message)
        {
            return View(MVC.Views.Errors.ValidationError,
                new ValidationError(Texts.Validation.InvalidResetToken));
        }

        public ActionResult Signout()
        {
            WebSecurityHelper.LogOut();
            Membership.User.LogOut(HttpContext);
            return new RedirectResult("~/");
        }
    }
}

namespace CustomerSave.Membership
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }

        private static string usernameKey = "usernameKey";

        public static User GetCurrentUser(string username)
        {
            var connection = DatabaseHelper.GetConnection();
            string query = "select * from dbo.Users where Username = @username";
            var user = connection.QueryFirst<User>(query, new { username });

            return user;
        }

        public static Task<User> GetCurrentUserAsync(string username)
        {
            return Task.Factory.StartNew(() => {
                return GetCurrentUser(username);
            });
        }

        public static User GetCurrentUser(HttpContext context)
        {
            return context.Session.Get<User>(usernameKey);
        }

        public static Task SaveUserToSession(string username, HttpContext context)
        {
            return Task.Factory.StartNew(() => {
                User currentUser = GetCurrentUser(username);
                context.Session.Set(usernameKey, currentUser);
            });
        }

        public static void LogOut(HttpContext context)
        {
            context.Session.Remove(usernameKey);
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}