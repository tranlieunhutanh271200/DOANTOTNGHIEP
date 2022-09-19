using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    public class TaskDetailDTO
    {
        public string TaskName { get; set; }
        public string Detail { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime DueTo { get; set; }
        public DateTime DoneAt { get; set; }
        public List<LogworkDetailDTO> Logworks { get; set; }
    }
}