using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class StudentClass
    {
        [Key]
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
        public int SemesterId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public virtual Semester Semester { get; set; }
        public int? SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual TeacherSubject Subject { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool IsCurrent => EndAt <= DateTime.Now;
    }
}
