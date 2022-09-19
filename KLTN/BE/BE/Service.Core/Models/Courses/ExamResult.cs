using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        [ForeignKey(nameof(ExamId))]
        public virtual ExamScript Exam { get; set; }
        public int Score { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

    }
}
