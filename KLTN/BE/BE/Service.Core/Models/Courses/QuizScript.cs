using System;

namespace Service.Core.Models.Courses
{
    public class QuizScript : SectionScript
    {
        public Guid QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsOnetimeQuiz { get; set; }

    }
}
