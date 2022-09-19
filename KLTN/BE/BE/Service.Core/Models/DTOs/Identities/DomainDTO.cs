using System;
using System.Collections.Generic;

namespace Service.Core.Models.DTOs.Identities
{
    public class DomainDTO
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string Abbreviation { get; set; }
        public string DomainStatus { get; set; }
        public string SchoolEmail { get; set; }

        public string SchoolUrl { get; set; }
        public string SchoolLogoPath { get; set; }
        public bool IsActive { get; set; }
        public Guid DomainAdminId { get; set; }
        public AccountDTO DomainAdmin { get; set; }
        public List<DomainComponentDTO> Components { get; set; }
    }
}
