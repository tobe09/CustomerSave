using FluentMigrator;
using System;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180720123625)]
    public class DefaultDB_20180720_123625_InitialPayments : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Payment")
                .Row(new
                {
                    CustomerId = 1,
                    Amount = 1500,
                    Description = "For Headache",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 53, 56)
                })
                .Row(new
                {
                    CustomerId = 2,
                    Amount = 1000,
                    Description = "For Christmas",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 54, 14)
                })
                .Row(new
                {
                    CustomerId = 1,
                    Amount = 2500,
                    Description = "For Clothes",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 54, 53)
                })
                .Row(new
                {
                    CustomerId = 4,
                    Amount = 3500,
                    Description = "For Books",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 55, 56)
                })
                .Row(new
                {
                    CustomerId = 3,
                    Amount = 14000,
                    Description = "For House Rent",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 16, 11, 57, 06)
                });
        }

        public override void Down()
        {
        }
    }
}
