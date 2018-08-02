using CustomerSave.Membership;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace CustomerSave.Web.Initialization
{
    public class LoginAuthenticationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            User admin = User.GetCurrentUser(context.HttpContext);
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            string controller = descriptor.ControllerName;
            string action = descriptor.ActionName;
            string path = controller + "/" + action;

            if (path != "Account/Login" && admin == null)
            {
                //user is not logged in
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{ { "controller", "Account" }, { "action", "Login" },
                    { "ReturnUrl", $"/{descriptor.AttributeRouteInfo.Template}"} });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
