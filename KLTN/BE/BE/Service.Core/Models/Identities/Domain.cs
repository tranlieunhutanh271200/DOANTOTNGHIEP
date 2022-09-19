using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Identities
{
    public class Domain : AuditEntity
    {
        public string Abbreviation { get; set; }
        public string SchoolName { get; set; }
        public string SchoolEmail { get; set; }
        public string SchoolAddress { get; set; }
        public bool IsActive { get; set; }
        public string SchoolUrl { get; set; }
        public Guid SchoolLogoId { get; set; }
        public string SchoolLogoPath { get; set; }
        public string DomainComponents { get; set; }
        public DomainStatus DomainStatus { get; set; }
        public Guid? DomainAdminId { get; set; }
        [ForeignKey(nameof(DomainAdminId))]
        public virtual Account DomainAdmin { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<DomainComponent> Components { get; set; }
        public virtual ICollection<DomainProcess> Processes { get; set; }
        public Domain()
        {
            Accounts = new List<Account>();
            Components = new List<DomainComponent>();
            Processes = new List<DomainProcess>();
        }
    }
}
