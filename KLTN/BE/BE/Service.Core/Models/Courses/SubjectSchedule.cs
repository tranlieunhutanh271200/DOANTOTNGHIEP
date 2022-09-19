using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class SubjectSchedule : AuditEntity
    {
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual TeacherSubject Subject { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalPeriod { get; set; }
        public DateTime EndTime { get; set; }
    }
}
