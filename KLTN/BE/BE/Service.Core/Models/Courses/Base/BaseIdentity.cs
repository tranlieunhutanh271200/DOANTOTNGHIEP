using System;

namespace Service.Core.Models.Courses.Base
{
    public class BaseIdentity : AuditEntity
    {
        public Guid DomainId { get; set; }
        public Guid AccountId { get; set; }
        public string Fullname { get; set; }
        public string IdentityNo { get; set; }
        public Guid AvatarId { get; set; }
        public int Gender { get; set; }
        public string AvatarUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; } = DateTime.MinValue;
        public bool IsAvailable => LeaveDate != DateTime.MinValue && LeaveDate < DateTime.Now;
    }
}
