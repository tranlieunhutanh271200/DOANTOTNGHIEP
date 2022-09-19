using System;

namespace CRM.API.Models
{
    public class SendMessageDTO
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public string HostFullname { get; set; }
        public string MemberFullname { get; set; }
        public Guid DomainId { get; set; }
    }
}