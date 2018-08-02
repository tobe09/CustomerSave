using FluentMigrator;
using System;

namespace CustomerSave.Migrations.DefaultDB
{
    [Migration(20180730105632)]
    public class DefaultDB_20180730_105632_InitialCommentTracks : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("CommentTracker")
                   .Row(new
                   {
                       PaymentId = 1,
                       ViewingAdminId = 1,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 53, 56)
                   })
                   .Row(new
                   {
                       PaymentId = 1,
                       ViewingAdminId = 2,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 53, 56)
                   })
                   .Row(new
                   {
                       PaymentId = 2,
                       ViewingAdminId = 1,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 54, 14)
                   })
                   .Row(new
                   {
                       PaymentId = 2,
                       ViewingAdminId = 2,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 54, 14)
                   })
                   .Row(new
                   {
                       PaymentId = 3,
                       ViewingAdminId = 1,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 54, 53)
                   })
                   .Row(new
                   {
                       PaymentId = 3,
                       ViewingAdminId = 2,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 54, 53)
                   })
                   .Row(new
                   {
                       PaymentId = 4,
                       ViewingAdminId = 1,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 55, 56)
                   })
                   .Row(new
                   {
                       PaymentId = 4,
                       ViewingAdminId = 2,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 55, 56)
                   })
                   .Row(new
                   {
                       PaymentId = 5,
                       ViewingAdminId = 1,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 57, 06)
                   })
                   .Row(new
                   {
                       PaymentId = 5,
                       ViewingAdminId = 2,
                       LastViewDate = new DateTime(2018, 07, 16, 11, 57, 06)
                   });
        }

        public override void Down()
        {
        }
    }
}
