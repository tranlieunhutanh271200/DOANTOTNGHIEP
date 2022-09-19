using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class ProjectCreateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Guid LeaderId { get; set; }
        public Guid ClassId { get; set; }
        public List<MemberDTO> Members { get; set; }
    }
}