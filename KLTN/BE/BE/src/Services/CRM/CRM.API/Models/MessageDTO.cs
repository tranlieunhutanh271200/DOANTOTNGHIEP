using System;

namespace CRM.API.Models
{
    public class MessageDTO
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public string SentAt { get; set; }
        public bool IsSeen { get; set; }
    }
}