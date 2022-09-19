using System;

namespace Realtime.API.Models
{
    public class OnlineUserKey
    {
        public Guid AccountId { get; set; }
        public string ConnectionId { get; set; }
    }
}