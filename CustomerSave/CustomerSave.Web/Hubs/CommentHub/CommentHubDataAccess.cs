using CustomerSave.Hubs.Classes;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace CustomerSave.Hubs
{
    public interface ICommentHubDataAccess
    {
        IEnumerable<Comment> GetCommentsForRecord(int paymentId);
        int InsertComment(Comment comment, int userId);
        PaymentInfo GetPaymentCustomerInfo(int paymentId);
        IEnumerable<CommentInfo> GetUnreadComments(int userId);
        int UpdateCommentTrackForPayment(int paymentId, int userId);
    }

    public class CommentHubDataAccess : ICommentHubDataAccess
    {
        private IDbConnection connection;

        public CommentHubDataAccess(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Comment> GetCommentsForRecord(int paymentId)
        {
            string query = $"select B.Username as AdminUsername, A.CommentText, A.PaymentId, A.CreatedDate as Date from [dbo].Comment as A " +
                           $"inner join [dbo].Users as B on A.CreatedBy = B.UserId and A.PaymentId = {paymentId} order by A.CreatedDate";
            IEnumerable<Comment> comments = connection.Query<Comment>(query);

            return comments;
        }

        public PaymentInfo GetPaymentCustomerInfo(int paymentId)
        {
            string query = $"select B.Username as CustomerUsername, B.CustomerGivenId, A.Description from [dbo].Payment as A inner join [dbo].Customer as B " +
                    $"on A.CustomerId = B.CustomerId and A.PaymentId={paymentId}";
            var paymentInfo = connection.QueryFirst<PaymentInfo>(query);

            return paymentInfo;
        }

        public int InsertComment(Comment comment, int userId)
        {
            string query = $"insert into [dbo].Comment values ({comment.PaymentId}, '{comment.CommentText}', {userId}, SYSDATETIME())";
            int status = connection.Execute(query);

            return status;
        }

        public IEnumerable<CommentInfo> GetUnreadComments(int userId)
        {
            string query = "select A.PaymentId, A.CreatedDate, C.Description, D.CustomerGivenId, E.Username from [dbo].Comment as A inner join " +
                "[dbo].CommentTracker as B on A.PaymentId = B.PaymentId and A.CreatedDate > B.LastViewDate and B.ViewingAdminId = @userId " +
                "inner join [dbo].Payment as C on A.Paymentid = C.PaymentId inner join [dbo].Customer as D on C.CustomerId = D.CustomerId inner join [dbo].Users as E " +
                "on A.CreatedBy = E.UserId";
            var unreadComments = connection.Query<CommentInfo>(query, new { userId });

            return unreadComments;
        }

        public int UpdateCommentTrackForPayment(int paymentId, int userId)
        {
            string query = "update [dbo].CommentTracker set LastViewDate = GetDate() where PaymentId = @paymentId and ViewingAdminId = @userId";
            return connection.Execute(query, new { paymentId, userId });
        }
    }
}
