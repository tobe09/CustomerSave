
namespace CustomerSave.Customer.Pages
{
    using CustomerSave.Hubs;
    using Microsoft.AspNetCore.Mvc;
    using Serenity.Web;
    using System;
    using System.Linq;

    [PageAuthorize(typeof(Entities.PaymentRow))]
    public class PaymentController : Controller
    {
        private ICommentHubService hubService;

        public PaymentController(ICommentHubService hubService)
        {
            this.hubService = hubService;
        }

        [Route("Customer/Payment")]
        public ActionResult Index()
        {            
            int userId = Membership.User.GetCurrentUser(HttpContext).UserId;
            var groupedComments = hubService.GetUnreadCommentsForUser(userId);

            var paymentId = HttpContext.Request.Query["paymentId"].FirstOrDefault();
            ViewData["PaymentId"] = paymentId == null ? -1 : Convert.ToInt32(paymentId);

            return View("~/Modules/Customer/Payment/PaymentIndex.cshtml", groupedComments);
        }
    }
}