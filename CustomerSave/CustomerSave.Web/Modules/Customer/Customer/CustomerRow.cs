
namespace CustomerSave.Customer.Entities
{
    using CustomerSave.BusinessRules;
    using CustomerSave.Customer;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Default"), Module("Customer"), TableName("[dbo].[Customer]")]
    [DisplayName("Customer"), InstanceName("Customer")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class CustomerRow : Row, IIdRow, INameRow
    {

        [DisplayName("Customer Id"), Identity]
        public Int32? CustomerId
        {
            get { return Fields.CustomerId[this]; }
            set { Fields.CustomerId[this] = value; }
        }

        [DisplayName("Customer Id"), Size(12), NotNull, QuickSearch]
        public String CustomerGivenId
        {
            get { return Fields.CustomerGivenId[this]; }
            set { Fields.CustomerGivenId[this] = value; }
        }

        [DisplayName("Username"), Size(50), NotNull, QuickSearch]
        public String Username
        {
            get { return Fields.Username[this]; }
            set { Fields.Username[this] = value; }
        }
        
        [DisplayName("First Name"), Size(50), NotNull]
        public String FirstName
        {
            get { return Fields.FirstName[this]; }
            set { Fields.FirstName[this] = value; }
        }

        [DisplayName("Last Name"), Size(50), NotNull]
        public String LastName
        {
            get { return Fields.LastName[this]; }
            set { Fields.LastName[this] = value; }
        }

        [DisplayName("Middle Name"), Size(50)]
        public String MiddleName
        {
            get { return Fields.MiddleName[this]; }
            set { Fields.MiddleName[this] = value; }
        }

        [DisplayName("Full Name"), Expression("(t0.LastName + ', ' + t0.FirstName + ISNULL(' ' + t0.MiddleName, ''))"), QuickSearch]
        public String FullName
        {
            get { return Fields.FullName[this]; }
            set { Fields.FullName[this] = value; }
        }

        [DisplayName("Email Address"), Width(280), NotNull]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Phone Number"), Width(150), NotNull]
        public Int64? PhoneNo
        {
            get { return Fields.PhoneNo[this]; }
            set { Fields.PhoneNo[this] = value; }
        }

        [DisplayName("Phone Number (2)")]
        public Int64? PhoneNo2
        {
            get { return Fields.PhoneNo2[this]; }
            set { Fields.PhoneNo2[this] = value; }
        }

        [DisplayName("Home Address"), Size(500), NotNull]
        public String HomeAddress
        {
            get { return Fields.HomeAddress[this]; }
            set { Fields.HomeAddress[this] = value; }
        }

        [DisplayName("Created By"), NotNull]
        public Int32? CreatedBy
        {
            get { return Fields.CreatedBy[this]; }
            set { Fields.CreatedBy[this] = value; }
        }

        [DisplayName("Created Date"), Width(150), NotNull]
        public DateTime? CreatedDate
        {
            get { return Fields.CreatedDate[this]; }
            set { Fields.CreatedDate[this] = value; }
        }

        [DisplayName("Modified By")]
        public Int32? ModifiedBy
        {
            get { return Fields.ModifiedBy[this]; }
            set { Fields.ModifiedBy[this] = value; }
        }

        [DisplayName("Modified Date")]
        public DateTime? ModifiedDate
        {
            get { return Fields.ModifiedDate[this]; }
            set { Fields.ModifiedDate[this] = value; }
        }


        public void Validate()
        {
            PropertyValidator.Validate(PropertyValidator.ValidateUsername, Username);
            PropertyValidator.Validate(PropertyValidator.ValidateName, FirstName, "First Name");
            PropertyValidator.Validate(PropertyValidator.ValidateName, LastName, "Last name");
            PropertyValidator.Validate(PropertyValidator.ValidateEmail, Email);
            PropertyValidator.Validate(PropertyValidator.ValidatePhoneNo, (long)PhoneNo, "First Phone Number");
            if (PhoneNo2 != null)
            {
                PropertyValidator.Validate(PropertyValidator.ValidatePhoneNo, (long)PhoneNo2, "Second Phone Number");
            }
            PropertyValidator.Validate(PropertyValidator.ValidateAddress, HomeAddress);
        }



        IIdField IIdRow.IdField
        {
            get { return Fields.CustomerId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CustomerGivenId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CustomerRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field CustomerId;

            public StringField CustomerGivenId;

            public StringField Username;

            public StringField FirstName;

            public StringField LastName;

            public StringField MiddleName;
            
            public StringField FullName;

            public StringField Email;

            public Int64Field PhoneNo;

            public Int64Field PhoneNo2;

            public StringField HomeAddress;

            public Int32Field CreatedBy;

            public DateTimeField CreatedDate;

            public Int32Field ModifiedBy;

            public DateTimeField ModifiedDate;


		}
    }
}
