
namespace CustomerSave.Common.Pages
{
    using CustomerSave.Hubs;
    using CustomerSave.Hubs.Classes;
    using Microsoft.AspNetCore.Mvc;
    using Serenity.Web;
    using System.Collections.Generic;
    using System.Linq;

    [Route("Dashboard/[action]")]
    public class DashboardController : Controller
    {
        private ICommentHubService hubService;

        public DashboardController(ICommentHubService hubService)
        {
            this.hubService = hubService;
        }

        [PageAuthorize, HttpGet, Route("~/")]
        public ActionResult Index()
        {
            int userId = Membership.User.GetCurrentUser(HttpContext).UserId;
            var groupedComments = hubService.GetUnreadCommentsForUser(userId);

            var model = new MyDashboardPagemodel { GroupedComments = groupedComments, DashboardPageModel = new DashboardPageModel() };

            return View(MVC.Views.Common.Dashboard.DashboardIndex, model);
        }

        public class MyDashboardPagemodel
        {
            public IEnumerable<IGrouping<int, CommentInfo>> GroupedComments { get; set; }
            public DashboardPageModel DashboardPageModel { get; set; }
        }
    }
}
