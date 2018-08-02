using FluentMigrator;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180723091115)]
    public class DefaultDB_20180723_091115_CommentsTable : Migration
    {
        public override void Up()
        {
            Create.Table("Comment")
            .WithColumn("CommentId").AsInt32().Identity().PrimaryKey().NotNullable()
            .WithColumn("PaymentId").AsInt32().ForeignKey("Payment", "PaymentId").NotNullable().Indexed()
            .WithColumn("CommentText").AsString(1000).NotNullable()
            .WithColumn("CreatedBy").AsInt32().ForeignKey("Users", "UserId").NotNullable()
            .WithColumn("CreatedDate").AsDateTime().NotNullable();

            Create.Index("UQ_Comment_Id_Key")
               .OnTable("Comment")
               .OnColumn("CommentId").Ascending()
               .OnColumn("PaymentId").Ascending()
               .WithOptions().Unique();
        }

        public override void Down()
        {
        }
    }
}
