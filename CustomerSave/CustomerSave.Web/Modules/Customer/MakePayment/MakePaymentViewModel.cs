
using CustomerSave.BusinessRules;
using System.ComponentModel.DataAnnotations;

namespace CustomerSave.Customer.MakePayment
{
    public class MakePaymentViewModel
    {
        [Display(Name = "Customer Given Id")]
        public string CustomerGivenId { get; set; }
        public string Username { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsSubmitDisabled { get; set; } = true;

        public void Validate()
        {
            PropertyValidator.Validate(PropertyValidator.ValidateAmount, Amount);
            PropertyValidator.Validate(PropertyValidator.ValidateString, Description, "Description");
        }
    }
}
