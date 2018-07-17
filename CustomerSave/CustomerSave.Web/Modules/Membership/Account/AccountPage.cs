
namespace CustomerSave.Membership.Pages
{
    using CustomerSave.Common;
    using Dapper;
    using Microsoft.AspNetCore.Mvc;
    using Serenity;
    using Serenity.Services;
    using System;
    using System.Linq;

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
                    SaveCurrentAdmin(username);
                    return new ServiceResponse();
                }

                throw new ValidationError("AuthenticationError", Texts.Validation.AuthenticationError);
            });
        }

        //persist administrator information to session
        private void SaveCurrentAdmin(string username)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() => {
                var connection = DatabaseHelper.GetConnection();
                string query = "select * from dbo.Users where Username = @username";
                Membership.User.CurrentUser = connection.Query<User>(query, new { username }).Single();  //user saved
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
            return new RedirectResult("~/");
        }
    }
}

namespace CustomerSave.Membership
{
    class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        

        public static User CurrentUser { get; set; }
    }
}