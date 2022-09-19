using System;

namespace API.Gateways.Models
{
    public class MemberDTO
    {
        public Guid AccountId { get; set; }
        public string MemberFullname { get; set; }
        public string StudentID { get; set; }
    }
}