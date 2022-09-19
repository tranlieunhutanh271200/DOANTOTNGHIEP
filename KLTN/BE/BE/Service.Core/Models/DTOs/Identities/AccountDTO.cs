using System;

namespace Service.Core.Models.DTOs.Identities
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhotoImage { get; set; }
        public string BackgroundImage { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsLocked { get; set; }
        public DateTime LastLockUntil { get; set; }
        public string Role { get; set; }
        public int Gender { get; set; }
        public DomainDTO Domain { get; set; }
    }
}
