using Microsoft.AspNetCore.Http;
using Service.Core.Models.Identities;

namespace Service.Core.Models.DTOs.Identities
{
    public class DomainCreateDTO
    {
        public string SchoolName { get; set; }
        public string Abbreviation { get; set; }
        public string SchoolUrl { get; set; }
        public string SchoolEmail { get; set; }
        public string SchoolAddress { get; set; }
        public string Nation { get; set; }
        public IFormFile File { get; set; }
        public bool IsActive { get; set; } = false;
        public DomainStatus Status { get; set; } = DomainStatus.NEW;
    }
}
