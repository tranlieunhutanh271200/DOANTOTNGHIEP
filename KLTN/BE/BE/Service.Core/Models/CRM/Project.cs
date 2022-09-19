using Service.Core.Models.LogWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Core.Models.CRM
{
    public class Project : AuditEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? LeaderId { get; set; }
        public string LeaderFullname { get; set; }
        public int SubjectId { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public bool IsDone => Tasks.Count > 0 && !Tasks.Any(t => t.Status != TaskStatus.DONE);
        public bool IsExpired => !IsDone && End < DateTime.Now;
        public virtual ICollection<Member> Members { get; set; }
        public Project()
        {
            Members = new List<Member>();
            Tasks = new List<Task>();
        }
    }
}