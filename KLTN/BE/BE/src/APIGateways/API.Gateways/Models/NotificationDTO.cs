using System;

namespace API.Gateways.Models
{
    public class NotificationDTO
    {
        public Guid AccountId { get; set; }
        public string Content { get; set; }
    }
}
