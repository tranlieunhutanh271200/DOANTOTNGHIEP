using System;

namespace API.Gateways.Models
{
    public class ExamScriptDTO : ScriptBaseDTO
    {
        public Guid ExamId { get; set; }
        public int Duration { get; set; }
        public int TotalAttempt { get; set; }
        public bool IsShuffle { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime DueTo { get; set; }
    }
}
