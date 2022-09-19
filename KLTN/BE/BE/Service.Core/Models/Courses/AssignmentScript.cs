using System;
using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public class AssignmentScript : SectionScript
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime DueTo { get; set; }
        public bool IsReopen { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
