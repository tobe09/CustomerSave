using System;

namespace CustomerSave.Hubs.Classes
{
    public class CommentInfo
    {
        public int PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string CustomerGivenId { get; set; }
        public string Username { get; set; }
    }
}
