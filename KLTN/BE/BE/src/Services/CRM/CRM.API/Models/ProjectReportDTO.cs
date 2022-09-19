using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    public class ProjectReportDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid LeaderId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public List<MemberDTO> Members { get; set; }
    }
}
