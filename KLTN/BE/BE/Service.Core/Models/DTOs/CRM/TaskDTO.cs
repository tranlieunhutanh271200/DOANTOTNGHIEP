using Service.Core.Models.DTOs.Identities;
using System;
using System.Collections.Generic;

namespace Service.Core.Models.DTOs.CRM
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Guid AssigneeId { get; set; }
        public AccountDTO Assignee { get; set; }
        public string Status { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime DueTo { get; set; }
        public int TotalSpent { get; set; }
        public List<LogworkDTO> LogTasks { get; set; }
    }
}
