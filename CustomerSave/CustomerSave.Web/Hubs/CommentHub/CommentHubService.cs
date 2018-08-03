using CustomerSave.Hubs.Classes;
using CustomerSave.Membership;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerSave.Hubs
{
    public interface ICommentHubService
    {
        IEnumerable<Comment> GetCommentsForRecord(int paymentId);
        CommentSaveResult SaveCommentForPayment(Comment comment, User userId);
        IEnumerable<IGrouping<int, CommentInfo>> GetUnreadCommentsForUser(int userId);
        int UpdateCommentTrackForPayment(int paymentId, int userId);
    }

    public class CommentHubService : ICommentHubService
    {
        private ICommentHubDataAccess hubDao;

        public CommentHubService(ICommentHubDataAccess hubDao)
        {
            this.hubDao = hubDao;
        }

        public IEnumerable<Comment> GetCommentsForRecord(int paymentId)
        {
            var comments = hubDao.GetCommentsForRecord(paymentId);

            return comments;
        }

        public CommentSaveResult SaveCommentForPayment(Comment comment, User user)
        {
            int status = hubDao.InsertComment(comment, user.UserId);

            var paymentInfo = hubDao.GetPaymentCustomerInfo(comment.PaymentId);

            comment.AdminUsername = user.UserName;
            comment.Date = DateTime.Now;

            return new CommentSaveResult { Comment = comment, PaymentInfo = paymentInfo };
        }

        public IEnumerable<IGrouping<int, CommentInfo>> GetUnreadCommentsForUser(int userId)
        {
            IEnumerable<CommentInfo> unreadComments = hubDao.GetUnreadComments(userId);
            var groupedComments = unreadComments.OrderByDescending(c => c.CreatedDate).GroupBy(c => c.PaymentId);

            return groupedComments;
        }

        public int UpdateCommentTrackForPayment(int paymentId, int userId)
        {
            return hubDao.UpdateCommentTrackForPayment(paymentId, userId);
        }
    }
}
