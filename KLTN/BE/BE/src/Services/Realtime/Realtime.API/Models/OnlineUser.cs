using System;

namespace Realtime.API.Models
{
    public class OnlineUser
    {
        public string ConnectionId { get; set; }
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public Guid DomainId { get; set; }
        public Guid RTCId { get; set; }
    }
}