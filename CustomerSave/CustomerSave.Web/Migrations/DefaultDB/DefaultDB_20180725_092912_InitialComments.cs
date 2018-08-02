using FluentMigrator;
using System;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180725092912)]
    public class DefaultDB_20180725_092912_InitialComments : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Comment")
                .Row(new
                {
                    PaymentId = 1,
                    CommentText = "Headaches are serious",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 25, 09, 31, 50)
                })
                .Row(new
                {
                    PaymentId = 1,
                    CommentText = "Its unbelievable",
                    CreatedBy = 2,
                    CreatedDate = new DateTime(2018, 07, 25, 09, 33, 12)
                })
                .Row(new
                {
                    PaymentId = 2,
                    CommentText = "He is planning ahead",
                    CreatedBy = 2,
                    CreatedDate = new DateTime(2018, 07, 25, 09, 34, 42)
                })
                .Row(new
                {
                    PaymentId = 2,
                    CommentText = "That is very true",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 25, 09, 32, 50)
                })
                .Row(new
                {
                    PaymentId = 3,
                    CommentText = "Clothes are important",
                    CreatedBy = 2,
                    CreatedDate = new DateTime(2018, 07, 25, 09, 33, 50)
                })
                .Row(new
                {
                    PaymentId = 4,
                    CommentText = "Books give knowledge",
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2018, 07, 25, 09, 34, 21)
                });
        }

        public override void Down()
        {
        }
    }
}
