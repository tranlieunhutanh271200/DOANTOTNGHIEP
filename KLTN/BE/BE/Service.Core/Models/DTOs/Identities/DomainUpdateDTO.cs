using System;
using System.Collections.Generic;

namespace Service.Core.Models.DTOs.Identities
{
    public class DomainUpdateDTO
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public string Abbreviation { get; set; }
        public string SchoolEmail { get; set; }
        public string Address { get; set; }
        public string DomainStatus { get; set; }
        public Guid DomainAdminId { get; set; }
        public List<DomainComponentDTO> DomainComponents { get; set; }
    }
}
