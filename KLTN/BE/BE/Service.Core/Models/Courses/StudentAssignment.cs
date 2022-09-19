using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class StudentAssignment : AuditEntity
    {
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
        public int AssigmentId { get; set; }
        [ForeignKey(nameof(AssigmentId))]
        public virtual AssignmentScript Assignment { get; set; }
        public Guid FileId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string AbsolutePath { get; set; }
    }
}
