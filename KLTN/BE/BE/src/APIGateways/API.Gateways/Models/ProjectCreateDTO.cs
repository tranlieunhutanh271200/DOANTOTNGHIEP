using System;
using System.Collections.Generic;

namespace API.Gateways.Models
{
    public class ProjectCreateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Guid LeaderId { get; set; }
        public string LeaderFullname { get; set; }
        public Guid OwnerId { get; set; }
        public int SubjectId { get; set; }
        public virtual List<MemberDTO> Members { get; set; }
    }
}