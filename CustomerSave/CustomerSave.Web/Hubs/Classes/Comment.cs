using System;

namespace CustomerSave.Hubs.Classes
{
    public class Comment
    {
        public string AdminUsername { get; set; }
        public string CommentText { get; set; }
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
    }
}
