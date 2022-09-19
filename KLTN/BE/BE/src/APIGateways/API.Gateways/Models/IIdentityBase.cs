using System;

namespace API.Gateways.Models
{
    public interface IIdentityBase
    {
        string PhoneNumber { get; set; }
        string IdentityNo { get; set; }
        string PermanentAddress { get; set; }
        string CurrentAddress { get; set; }
        string BirthDate { get; set; }
        Guid AccountId { get; set; }
        Guid AvatarId { get; set; }
        string AvatarUrl { get; set; }
        string FullName { get; set; }
    }
}