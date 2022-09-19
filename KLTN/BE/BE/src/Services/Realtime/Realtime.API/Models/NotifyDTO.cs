using System;

namespace Realtime.API.Models
{
    public class NotifyDTO
    {
        public string Content { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}