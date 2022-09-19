using Service.Core.Models.DTOs.CRM;
using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsExpired { get; set; }
        public Guid LeaderId { get; set; }
        public string LeaderFullname { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public List<MemberDTO> Members { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
}