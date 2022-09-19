using System;

namespace CRM.API.Models
{
    public class MemberDTO
    {
        public Guid AccountId { get; set; }
        public string MemberFullname { get; set; }
        public string StudentID { get; set; }
    }
}