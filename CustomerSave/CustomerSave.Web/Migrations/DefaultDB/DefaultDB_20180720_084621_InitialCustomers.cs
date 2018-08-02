using FluentMigrator;
using System;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180720084621)]
    public class DefaultDB_20180720_084621_InitialCustomers : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Customer")
                .Row(new
                {
                    CustomerGivenId = "CUSTOMER0001",
                    Username = "Tobe",
                    FirstName = "Tobenna",
                    LastName = "Chineke",
                    MiddleName = "Chinonso",
                    Email = "chineketobenna@gmail.com",
                    PhoneNo = 08136831102,
                    PhoneNo2 = 09050996827,
                    HomeAddress = "1 Sadiku Street, olodi-Apapa, Lagos",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 20, 11, 50, 24),
                    ModifiedBy = default(int?),
                    ModifiedDate = default(DateTime?)
                })
                .Row(new
                {
                    CustomerGivenId = "CUSTOMER0002",
                    Username = "Ade",
                    FirstName = "Adekunle",
                    LastName = "Folajinmi",
                    MiddleName = (string)null,
                    Email = "adekunle@gmail.com",
                    PhoneNo = 09033987678,
                    PhoneNo2 = default(long?),
                    HomeAddress = "32 Wilmer Crescent, Apapa, Lagos",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 20, 11, 51, 24),
                    ModifiedBy = default(int?),
                    ModifiedDate = default(DateTime?)
                })
                .Row(new
                {
                    CustomerGivenId = "CUSTOMER0003",
                    Username = "Abu",
                    FirstName = "Abubakar",
                    LastName = "Salisu",
                    MiddleName = "Yusuf",
                    Email = "abubakar@gmail.com",
                    PhoneNo = 09038765435,
                    PhoneNo2 = default(long?),
                    HomeAddress = "14 CAC Street, Badagry, Lagos",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 52, 21),
                    ModifiedBy = default(int?),
                    ModifiedDate = default(DateTime?)
                })
                .Row(new
                {
                    CustomerGivenId = "CUSTOMER0004",
                    Username = "John",
                    FirstName = "Jonathan",
                    LastName = "Bradley",
                    MiddleName = "Philip",
                    Email = "jonathan@gmail.com",
                    PhoneNo = 081688776655,
                    PhoneNo2 = 08022334433,
                    HomeAddress = "298b Corporation Drive, Dolphin Estate, Ikoyi, Lagos",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 52, 56),
                    ModifiedBy = default(int?),
                    ModifiedDate = default(DateTime?)
                });
        }

        public override void Down()
        {
        }
    }
}
