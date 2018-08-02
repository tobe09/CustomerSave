using FluentMigrator;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180730100217)]
    public class DefaultDB_20180730_100217_CommentTrackerTable : Migration
    {
        public override void Up()
        {
            Create.Table("CommentTracker")
            .WithColumn("CommentTrackId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("PaymentId").AsInt32().ForeignKey("Payment", "PaymentId").NotNullable().Indexed()
            .WithColumn("ViewingAdminId").AsInt32().ForeignKey("Users", "UserId").NotNullable()
            .WithColumn("LastViewDate").AsDateTime().NotNullable();

            Create.Index("UQ_CommentTracker_Id_Key")
               .OnTable("CommentTracker")
               .OnColumn("CommentTrackId").Ascending()
               .OnColumn("PaymentId").Ascending()
               .WithOptions().Unique();
        }

        public override void Down()
        {
        }
    }
}
