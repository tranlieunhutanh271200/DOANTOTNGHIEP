using Service.Core.Models.Consts;
using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public abstract class Question : AuditEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsCountdown { get; set; }
        public int TotalSeconds { get; set; }
        public int Score { get; set; }
        public TextFormatType Format { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public abstract bool CheckAnwer(Answer answer);
    }
}
