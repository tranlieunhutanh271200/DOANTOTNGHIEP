using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }
        public Guid DomainId { get; set; }
        public int Year { get; set; }
        public string SemesterName { get; set; }
        public DateTime SemesterStart { get; set; }
        public DateTime SemesterEnd { get; set; }
        public virtual ICollection<StudentClass> Classes { get; set; }
        public virtual ICollection<TeacherSubject> Subjects { get; set; }
        public Semester()
        {
            Classes = new List<StudentClass>();
            Subjects = new List<TeacherSubject>();
        }
    }
}
