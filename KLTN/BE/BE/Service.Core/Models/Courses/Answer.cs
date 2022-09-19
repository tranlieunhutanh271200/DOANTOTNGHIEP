using Service.Core.Models.Consts;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public abstract class Answer : AuditEntity
    {
        public string Content { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public Guid QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public virtual Question Questions { get; set; }
        public TextFormatType Format { get; set; }
    }
}
