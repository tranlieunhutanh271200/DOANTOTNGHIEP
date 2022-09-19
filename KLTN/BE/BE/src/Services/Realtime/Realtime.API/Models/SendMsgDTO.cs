using System;

namespace Realtime.API.Models
{
    public class SendMsgDTO
    {
        public Guid ToAccountId { get; set; }
        public string Content { get; set; }
    }
}