using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Identities
{
    public class Account : AuditEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhotoImage { get; set; }
        public string BackgroundImage { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsLocked { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        public Guid DomainId { get; set; }
        [ForeignKey(nameof(DomainId))]
        public virtual Domain Domain { get; set; }
        public Guid? ManageDomainId { get; set; }
        public virtual Domain ManageDomain { get; set; }
        public string RefreshToken { get; set; }
        public virtual ICollection<ProviderAuth> ProvidersAuth { get; set; }
        public virtual ICollection<DomainProcess> SentEmails { get; set; }
        public DateTime LastLockUntil { get; set; } = DateTime.MinValue;
        public Account()
        {
            ProvidersAuth = new List<ProviderAuth>();
            SentEmails = new List<DomainProcess>();
        }
    }
}
