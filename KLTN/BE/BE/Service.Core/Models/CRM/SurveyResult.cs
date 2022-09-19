using System;

namespace Service.Core.Models.CRM
{
    public class SurveyResult
    {
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        public DateTime SurveyAt { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }
    }
}