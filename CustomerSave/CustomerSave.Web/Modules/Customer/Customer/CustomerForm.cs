
namespace CustomerSave.Customer.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("Customer.Customer")]
    [BasedOnRow(typeof(Entities.CustomerRow), CheckNames = true)]
    public class CustomerForm
    {
        public String Username { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public String Email { get; set; }
        public Int64 PhoneNo { get; set; }
        public Int64 PhoneNo2 { get; set; }
        public String HomeAddress { get; set; }
    }
}