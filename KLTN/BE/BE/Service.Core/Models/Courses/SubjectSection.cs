using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class SubjectSection : AuditEntity
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TeacherSubjectId { get; set; }
        [ForeignKey(nameof(TeacherSubjectId))]
        public virtual TeacherSubject TeacherSubject { get; set; }
        public Guid? RootId { get; set; }
        public virtual SubjectSection Root { get; set; }
        public virtual ICollection<SectionScript> Scripts { get; set; }
        public virtual ICollection<SubjectSection> Children { get; set; }
        public SubjectSection()
        {
            Scripts = new List<SectionScript>();
            Children = new List<SubjectSection>();
        }
    }
}
