using System;

namespace API.Gateways.Models
{
    public class SendMessageDTO
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public string HostFullname { get; set; }
        public string MemberFullname { get; set; }
        public Guid DomainId { get; set; }
    }
}