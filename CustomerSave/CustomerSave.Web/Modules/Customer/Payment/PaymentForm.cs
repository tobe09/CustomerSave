
namespace CustomerSave.Customer.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("Customer.Payment"), Updatable(false)]
    [BasedOnRow(typeof(Entities.PaymentRow), CheckNames = true)]
    public class PaymentForm
    {
        [Hidden]
        public Int32 CustomerId { get; set; }
        public String CustomerCustomerGivenId { get; set; }
        public String CustomerUsername { get; set; }
        public String CustomerFirstName { get; set; }
        public String CustomerLastName { get; set; }
        public Decimal Amount { get; set; }
        public String Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String Total { get; set; }
    }
}