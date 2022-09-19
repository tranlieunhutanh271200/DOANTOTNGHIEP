using System;

namespace Realtime.API.Models
{
    public class MessageConnectDTO
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public Guid DomainId { get; set; }
        public string FullName { get; set; }
    }
}