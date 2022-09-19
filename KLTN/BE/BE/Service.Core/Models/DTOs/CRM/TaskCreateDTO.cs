using Service.Core.Models.LogWork;
using System;

namespace Service.Core.Models.DTOs.CRM
{
    public class TaskCreateDTO
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Guid AssigneeId { get; set; }
        public string AssigneeFullname { get; set; }
        public Guid ProjectId { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.TODO;
        public DateTime StartAt { get; set; } = DateTime.Now;
        public DateTime DueTo { get; set; } = DateTime.Now.AddDays(5);
    }
}
