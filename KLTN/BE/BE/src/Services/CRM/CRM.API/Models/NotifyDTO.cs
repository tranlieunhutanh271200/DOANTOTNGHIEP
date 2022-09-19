using System;

namespace CRM.API.Models
{
    public class NotifyDTO
    {
        public Guid AccountId { get; set; }
        public string Content { get; set; }
    }
}