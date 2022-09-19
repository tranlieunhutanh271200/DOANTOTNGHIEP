using System;

namespace Service.Core.Models.DTOs.CRM
{
    public class TaskUpdateDTO
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartAt { get; set; } = DateTime.Now;
        public DateTime DueTo { get; set; } = DateTime.Now.AddDays(5);
    }
}
