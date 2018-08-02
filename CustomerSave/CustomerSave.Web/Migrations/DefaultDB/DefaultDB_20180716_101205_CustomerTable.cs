using CustomerSave.BusinessRules;
using FluentMigrator;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180716101205)]
    public class DefaultDB_20180716_101205_CustomerTable : Migration
    {
        public override void Up()
        {
            Create.Table("Customer")
            .WithColumn("CustomerId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("CustomerGivenId").AsString(Constants.CustomerGivenIdLength).NotNullable()
            .WithColumn("Username").AsString(Constants.MaxUsernameLength).NotNullable()
            .WithColumn("FirstName").AsString(Constants.MaxNameLength).NotNullable()
            .WithColumn("LastName").AsString(Constants.MaxNameLength).NotNullable()
            .WithColumn("MiddleName").AsString(Constants.MaxNameLength).Nullable()
            .WithColumn("Email").AsString(200).NotNullable()
            .WithColumn("PhoneNo").AsInt64().NotNullable()
            .WithColumn("PhoneNo2").AsInt64().Nullable()
            .WithColumn("HomeAddress").AsString(500).NotNullable()
            .WithColumn("CreatedBy").AsInt32().NotNullable()
            .WithColumn("CreatedDate").AsDateTime().NotNullable()
            .WithColumn("ModifiedBy").AsInt32().Nullable()
            .WithColumn("ModifiedDate").AsDateTime().Nullable();

            Create.Index("UQ_Customer_Id_Key")
               .OnTable("Customer")
               .OnColumn("CustomerId").Ascending()
               .OnColumn("CustomerGivenId").Ascending()
               .WithOptions().Unique();
        }

        public override void Down()
        {
        }
    }
}
