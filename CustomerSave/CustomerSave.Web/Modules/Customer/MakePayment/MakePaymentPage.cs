
namespace CustomerSave.Customer.Pages
{
    using CustomerSave.Customer.MakePayment;
    using Microsoft.AspNetCore.Mvc;

    public class MakePaymentController : Controller
    {
        private IMakePaymentService makePaymentService = new MakePaymentService();

        [Route("Customer/MakePayment")]
        public ActionResult Index()
        {
            return View("~/Modules/Customer/MakePayment/MakePaymentIndex.cshtml");
        }

        [HttpPost]
        [Route("Customer/PostPayment")]
        public ActionResult PostPayment(MakePaymentViewModel model)
        {
            string errMsg = makePaymentService.PostPayment(model, Membership.User.CurrentUser.UserId);

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

        [Route("Customer/GetCustomerByGivenId")]
        public ActionResult GetCustomerByGivenId(string customerGivenId)
        {
            var customer = makePaymentService.GetCustomerByGivenId(customerGivenId);
            
            return Json(customer);
        }

        [Route("Customer/GetCustomerByUsername")]
        public ActionResult GetCustomerByUsername(string username)
        {
            var customer = makePaymentService.GetCustomerByUsername(username);

            return Json(customer);
        }
    }
}