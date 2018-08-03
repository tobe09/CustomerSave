using CustomerSave.Hubs.Classes;
using CustomerSave.Membership;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace CustomerSave.Hubs
{
    public class CommentHub : Hub
    {
        ICommentHubService hubService;
        IHttpContextAccessor contextAccessor;

        public CommentHub(ICommentHubService hubService, IHttpContextAccessor contextAccessor) : base()
        {
            this.hubService = hubService;
            this.contextAccessor = contextAccessor;
        }

        public async void GetCommentsForRecord(int paymentId)
        {
            var comments = hubService.GetCommentsForRecord(paymentId);

            await Clients.Caller.SendAsync("displayCommentsForRecord", comments);  //send comments to caller
        }

        public async void SaveComment(Comment comment)
        {
            var user = User.GetCurrentUser(contextAccessor.HttpContext);

            var result = hubService.SaveCommentForPayment(comment, user);

            await Clients.All.SendAsync("commentAdded", result);     //broadcast to clients
        }

        public void UpdateCommentTrackForPayment(int paymentId)
        {
            int userId = User.GetCurrentUser(contextAccessor.HttpContext).UserId;

            hubService.UpdateCommentTrackForPayment(paymentId, userId);
        }
    }
}
