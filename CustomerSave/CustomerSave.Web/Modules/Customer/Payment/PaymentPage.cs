
namespace CustomerSave.Customer.Pages
{
    using Serenity;
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.PaymentRow))]
    public class PaymentController : Controller
    {
        [Route("Customer/Payment")]
        public ActionResult Index()
        {
            return View("~/Modules/Customer/Payment/PaymentIndex.cshtml");
        }
    }
}