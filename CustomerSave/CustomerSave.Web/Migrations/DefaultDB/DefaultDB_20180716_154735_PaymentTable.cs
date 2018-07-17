using FluentMigrator;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180716154735)]
    public class DefaultDB_20180716_154735_PaymentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Payment")
            .WithColumn("PaymentId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("CustomerId").AsInt32().ForeignKey("Customer", "CustomerId").NotNullable()
            .WithColumn("Amount").AsDecimal().NotNullable()
            .WithColumn("Description").AsString(1000).NotNullable()
            .WithColumn("CreatedBy").AsInt32().NotNullable()
            .WithColumn("CreatedDate").AsDateTime().NotNullable();
        }

        public override void Down()
        {
        }
    }
}
