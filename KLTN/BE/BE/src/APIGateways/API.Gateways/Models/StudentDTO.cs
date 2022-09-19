using System;

namespace API.Gateways.Models
{
    public class StudentDTO : BaseDTO, IIdentityBase
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string StudentID { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNo { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string BirthDate { get; set; }
        public Guid AccountId { get; set; }
        public Guid AvatarId { get; set; }
        public string AvatarUrl { get; set; }
    }
}