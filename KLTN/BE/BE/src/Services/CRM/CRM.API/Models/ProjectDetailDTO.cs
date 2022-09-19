using Service.Core.Models.DTOs.Identities;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class ProjectDetailDTO
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public AccountDTO Leader { get; set; }
        public List<MemberDetailDTO> Members { get; set; }
    }
}