using System;

namespace Service.Core.Models.CRM
{
    public class Member
    {
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public Guid AccountId { get; set; }
        public string MemberFullname { get; set; }
        public string StudentID { get; set; }
    }
}