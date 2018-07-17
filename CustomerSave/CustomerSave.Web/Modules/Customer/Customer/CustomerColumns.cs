
namespace CustomerSave.Customer.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Customer.Customer")]
    [BasedOnRow(typeof(Entities.CustomerRow), CheckNames = true)]
    public class CustomerColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Hidden]
        public Int32 CustomerId { get; set; }
        [EditLink]
        public String CustomerGivenId { get; set; }
        public String Username { get; set; }
        public String FullName { get; set; }
        public String Email { get; set; }
        public Int64 PhoneNo { get; set; }
        public String HomeAddress { get; set; }
    }
}