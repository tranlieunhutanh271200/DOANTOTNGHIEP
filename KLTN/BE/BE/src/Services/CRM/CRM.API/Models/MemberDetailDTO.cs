using Service.Core.Models.DTOs.Identities;
using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class MemberDetailDTO
    {
        public Guid AccountId { get; set; }
        public AccountDTO Account { get; set; }
        public string FullName { get; set; }
        public Guid ClassId { get; set; }
        public string SubjectName { get; set; }
        public double DonePercent { get; set; }
        public List<TaskDetailDTO> Tasks { get; set; }
    }
}