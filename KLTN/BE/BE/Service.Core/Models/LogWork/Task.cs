using Service.Core.Models.CRM;
using System;
using System.Collections.Generic;

namespace Service.Core.Models.LogWork
{
    public class Task : AuditEntity
    {
        public string TaskName { get; set; }
        public Guid AssigneeId { get; set; }
        public string AssigneeFullname { get; set; }
        public string Description { get; set; }
        public Guid SupervisorId { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime DoneAt { get; set; }
        public DateTime DueTo { get; set; }
        public Guid? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<LogTask> LogTasks { get; set; }
    }
}
