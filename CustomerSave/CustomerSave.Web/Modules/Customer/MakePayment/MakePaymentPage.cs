
namespace CustomerSave.Customer.Pages
{
    using CustomerSave.Customer.MakePayment;
    using Microsoft.AspNetCore.Mvc;

    public class MakePaymentController : Controller
    {
        private IMakePaymentService makePaymentService;

        public MakePaymentController(IMakePaymentService makePaymentService)
        {
            this.makePaymentService = makePaymentService;
        }

        [Route("Customer/MakePayment")]
        public ActionResult Index()
        {
            return View("~/Modules/Customer/MakePayment/MakePaymentIndex.cshtml");
        }

        [HttpPost]
        [Route("MakePayment/[action]")]
        public ActionResult PostPayment(MakePaymentViewModel model)
        {
            string errMsg = makePaymentService.PostPayment(model, Membership.User.GetCurrentUser(Request.HttpContext).UserId);

            if (errMsg != null)
            {
                ViewBag.CssClass = "text-danger";
                ViewBag.Message = errMsg;
                model.IsSubmitDisabled = false;
                return View("~/Modules/Customer/MakePayment/MakePaymentIndex.cshtml", model);
            }

            ViewBag.CssClass = "text-success";
            ViewBag.Message = $"Successfully posted N{model.Amount.ToString("F2")} for {model.Username}";
            ModelState.Clear();

            return View("~/Modules/Customer/MakePayment/MakePaymentIndex.cshtml");
        }

        [Route("Customer/[action]")]
        public ActionResult GetCustomerByGivenId(string customerGivenId)
        {
            var customer = makePaymentService.GetCustomerByGivenId(customerGivenId);
            
            return Json(customer);
        }

        [Route("Customer/[action]")]
        public ActionResult GetCustomerByUsername(string username)
        {
            var customer = makePaymentService.GetCustomerByUsername(username);

            return Json(customer);
        }
    }
}