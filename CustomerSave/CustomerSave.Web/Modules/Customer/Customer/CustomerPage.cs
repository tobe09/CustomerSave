
namespace CustomerSave.Customer.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Serenity.Web;

    [PageAuthorize(typeof(Entities.CustomerRow))]
    public class CustomerController : Controller
    {
        [Route("Customer/Customer")]
        public ActionResult Index()
        {
            return View("~/Modules/Customer/Customer/CustomerIndex.cshtml");
        }
    }
}