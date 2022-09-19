using System;
using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public class Exam : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AutoStartDate { get; set; }
        public int Duration { get; set; }
        public int TotalAttempts { get; set; }
        public bool IsRandomize { get; set; }
        public int TotalQuestions => Questions.Count;
        public int TotalScore { get; set; }
        public Guid? OwnerId { get; set; }
        public virtual Teacher Owner { get; set; }
        public virtual ICollection<QuestionAllocation> Questions { get; set; }
        public virtual ExamScript Script { get; set; }
        public Exam()
        {
            Questions = new List<QuestionAllocation>();
        }
    }
}
