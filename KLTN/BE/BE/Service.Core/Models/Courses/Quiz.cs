using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public class Quiz : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCountdown { get; set; }
        public int TotalSeconds { get; set; }
        public int TotalQuestions => Questions.Count;
        public virtual ICollection<QuestionAllocation> Questions { get; set; }
        public virtual QuizScript QuizScript { get; set; }
    }
}
