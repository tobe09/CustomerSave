
namespace CustomerSave.Customer.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Customer.Payment")]
    [BasedOnRow(typeof(Entities.PaymentRow), CheckNames = true)]
    public class PaymentColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Hidden]
        public Int32 PaymentId { get; set; }
        [EditLink]
        public String CustomerCustomerGivenId { get; set; }
        public String CustomerFullName { get; set; }
        public Decimal Amount { get; set; }
        public String Description { get; set; }
    }
}