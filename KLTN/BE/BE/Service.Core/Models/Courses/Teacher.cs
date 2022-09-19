using Service.Core.Models.Courses.Base;
using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public class Teacher : BaseIdentity
    {
        public string TeacherID { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<TeachingHistory> TeachingHistories { get; set; }
    }
}
