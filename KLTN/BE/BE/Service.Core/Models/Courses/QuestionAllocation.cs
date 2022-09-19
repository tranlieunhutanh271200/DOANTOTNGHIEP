using System;

namespace Service.Core.Models.Courses
{
    public class QuestionAllocation
    {
        public int Id { get; set; }
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public Guid? ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public Guid? QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
