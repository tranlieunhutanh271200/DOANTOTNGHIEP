using Service.Core.Models.Courses.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class Student : BaseIdentity
    {
        public string StudentID { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual StudentCategory Category { get; set; }
        public virtual ICollection<StudentClass> Classes { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
