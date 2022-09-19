using System;
using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public class ExamScript : SectionScript
    {
        public Guid ExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int TotalAttempt { get; set; }
        public bool IsShuffle { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime DueTo { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
