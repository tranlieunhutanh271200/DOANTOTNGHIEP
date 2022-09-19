using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }
        public int? SemesterId { get; set; }
        [ForeignKey(nameof(SemesterId))]
        public virtual Semester Semester { get; set; }
        public Guid? SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
        public string Code { get; set; } = "Default";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<SubjectSchedule> Schedules { get; set; }
        public virtual ICollection<SubjectSection> Sections { get; set; }
        public virtual ICollection<BaremScore> BaremScores { get; set; }
        public virtual ICollection<StudentClass> Students { get; set; }
        public TeacherSubject()
        {
            Schedules = new List<SubjectSchedule>();
            Sections = new List<SubjectSection>();
        }
    }
}
