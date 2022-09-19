using System;
namespace Service.Core.Models.CRM
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? AccountId { get; set; }
    }
}
