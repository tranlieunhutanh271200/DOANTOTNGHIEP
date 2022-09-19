using System;

namespace Service.Core.Models.DTOs.CRM
{
    public class LogworkDTO
    {
        public DateTime LogAt { get; set; } = DateTime.Now;
        public int Duration { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
    }
}
