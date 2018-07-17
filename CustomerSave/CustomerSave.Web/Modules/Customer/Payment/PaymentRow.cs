
namespace CustomerSave.Customer.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Default"), Module("Customer"), TableName("[dbo].[Payment]")]
    [DisplayName("Payment"), InstanceName("Payment")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class PaymentRow : Row, IIdRow, INameRow
    {

        [DisplayName("Payment Id"), Identity]
        public Int32? PaymentId
        {
            get { return Fields.PaymentId[this]; }
            set { Fields.PaymentId[this] = value; }
        }

        [DisplayName("Customer"), NotNull, ForeignKey("[dbo].[Customer]", "CustomerId"), LeftJoin("jCustomer"), TextualField("CustomerCustomerGivenId")]
        public Int32? CustomerId
        {
            get { return Fields.CustomerId[this]; }
            set { Fields.CustomerId[this] = value; }
        }

        [DisplayName("Amount"), Size(19), DecimalEditor(Decimals = 2, PadDecimals = true), NotNull]
        public Decimal Amount
        {
            get { return Fields.Amount[this]; }
            set { Fields.Amount[this] = value; }
        }

        [DisplayName("Description"), Size(1000), NotNull, QuickSearch]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        [DisplayName("Created By"), NotNull]
        public Int32? CreatedBy
        {
            get { return Fields.CreatedBy[this]; }
            set { Fields.CreatedBy[this] = value; }
        }

        [DisplayName("Created Date"), NotNull]
        public DateTime? CreatedDate
        {
            get { return Fields.CreatedDate[this]; }
            set { Fields.CreatedDate[this] = value; }
        }



        [DisplayName("Customer Given Id"), Expression("jCustomer.[CustomerGivenId]")]
        public String CustomerCustomerGivenId
        {
            get { return Fields.CustomerCustomerGivenId[this]; }
            set { Fields.CustomerCustomerGivenId[this] = value; }
        }

        [DisplayName("Username"), Expression("jCustomer.[Username]")]
        public String CustomerUsername
        {
            get { return Fields.CustomerUsername[this]; }
            set { Fields.CustomerUsername[this] = value; }
        }

        [DisplayName("First Name"), Expression("jCustomer.[FirstName]")]
        public String CustomerFirstName
        {
            get { return Fields.CustomerFirstName[this]; }
            set { Fields.CustomerFirstName[this] = value; }
        }

        [DisplayName("Last Name"), Expression("jCustomer.[LastName]")]
        public String CustomerLastName
        {
            get { return Fields.CustomerLastName[this]; }
            set { Fields.CustomerLastName[this] = value; }
        }

        [DisplayName("Middle Name"), Expression("jCustomer.[MiddleName]")]
        public String CustomerMiddleName
        {
            get { return Fields.CustomerMiddleName[this]; }
            set { Fields.CustomerMiddleName[this] = value; }
        }

        [DisplayName("Full Name"), Expression("(jCustomer.FirstName + ', ' + jCustomer.LastName + ISNULL(' ' + jCustomer.MiddleName, ''))")]
        public String CustomerFullName
        {
            get { return Fields.CustomerFullName[this]; }
            set { Fields.CustomerFullName[this] = value; }
        }

        [DisplayName("Customer Email"), Expression("jCustomer.[Email]")]
        public String CustomerEmail
        {
            get { return Fields.CustomerEmail[this]; }
            set { Fields.CustomerEmail[this] = value; }
        }

        [DisplayName("Customer Phone No"), Expression("jCustomer.[PhoneNo]")]
        public Int64? CustomerPhoneNo
        {
            get { return Fields.CustomerPhoneNo[this]; }
            set { Fields.CustomerPhoneNo[this] = value; }
        }

        [DisplayName("Customer Phone No2"), Expression("jCustomer.[PhoneNo2]")]
        public Int64? CustomerPhoneNo2
        {
            get { return Fields.CustomerPhoneNo2[this]; }
            set { Fields.CustomerPhoneNo2[this] = value; }
        }

        [DisplayName("Customer Home Address"), Expression("jCustomer.[HomeAddress]")]
        public String CustomerHomeAddress
        {
            get { return Fields.CustomerHomeAddress[this]; }
            set { Fields.CustomerHomeAddress[this] = value; }
        }

        [DisplayName("Customer Created By"), Expression("jCustomer.[CreatedBy]")]
        public Int32? CustomerCreatedBy
        {
            get { return Fields.CustomerCreatedBy[this]; }
            set { Fields.CustomerCreatedBy[this] = value; }
        }

        [DisplayName("Customer Created Date"), Expression("jCustomer.[CreatedDate]")]
        public DateTime? CustomerCreatedDate
        {
            get { return Fields.CustomerCreatedDate[this]; }
            set { Fields.CustomerCreatedDate[this] = value; }
        }

        [DisplayName("Customer Modified By"), Expression("jCustomer.[ModifiedBy]")]
        public Int32? CustomerModifiedBy
        {
            get { return Fields.CustomerModifiedBy[this]; }
            set { Fields.CustomerModifiedBy[this] = value; }
        }

        [DisplayName("Customer Modified Date"), Expression("jCustomer.[ModifiedDate]")]
        public DateTime? CustomerModifiedDate
        {
            get { return Fields.CustomerModifiedDate[this]; }
            set { Fields.CustomerModifiedDate[this] = value; }
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.PaymentId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Description; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public PaymentRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field PaymentId;

            public Int32Field CustomerId;

            public DecimalField Amount;

            public StringField Description;

            public Int32Field CreatedBy;

            public DateTimeField CreatedDate;



            public StringField CustomerCustomerGivenId;

            public StringField CustomerUsername;

            public StringField CustomerFirstName;

            public StringField CustomerLastName;

            public StringField CustomerMiddleName;

            public StringField CustomerFullName;

            public StringField CustomerEmail;

            public Int64Field CustomerPhoneNo;

            public Int64Field CustomerPhoneNo2;

            public StringField CustomerHomeAddress;

            public Int32Field CustomerCreatedBy;

            public DateTimeField CustomerCreatedDate;

            public Int32Field CustomerModifiedBy;

            public DateTimeField CustomerModifiedDate;


		}
    }
}
