using Microsoft.AspNetCore.Http;
using System;

namespace API.Gateways.Models
{
    public class ScriptDTO : BaseDTO
    {
        public int Id { get; set; }
        public Guid SectionId { get; set; }
        public string ScriptType { get; set; }
        public string AssignmentScriptTitle { get; set; }
        public string Detail { get; set; }
        public string AssignmentScriptDescription { get; set; }
        public string AssignmentScriptOpenAt { get; set; }
        public string AssignmentScriptDueTo { get; set; }
        public int Order { get; set; }
        public bool IsReopen { get; set; }
        public string Heading { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentPassword { get; set; }
        public string DocumentUrl { get; set; }
        public Guid FileId { get; set; }
        public string FileType { get; set; }
        public string ExamId { get; set; }
        public int Duration { get; set; }
        public int TotalAttempt { get; set; }
        public bool IsShuffle { get; set; }
        public string OpenAt { get; set; }
        public string DueTo { get; set; }
        public IFormFile File { get; set; }
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsOnetimeQuiz { get; set; }
        public string VideoScriptTitle { get; set; }
        public string VideoScriptDescription { get; set; }
        public string VideoPath { get; set; }
        public Guid VideoId { get; set; }
    }
}
