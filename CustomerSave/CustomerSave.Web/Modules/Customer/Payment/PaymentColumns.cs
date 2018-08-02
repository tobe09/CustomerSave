
namespace CustomerSave.Customer.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Customer.Payment")]
    [BasedOnRow(typeof(Entities.PaymentRow), CheckNames = true)]
    public class PaymentColumns
    {
        public PaymentColumns()
        {
            AmountString = "Testing";
        }

        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Hidden]
        public Int32 PaymentId { get; set; }
        [EditLink]
        public String CustomerCustomerGivenId { get; set; }
        public String CustomerFullName { get; set; }
        public String AmountString { get; set; }
        public String Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        [EditLink]
        public String Comment { get; set; }
    }
}