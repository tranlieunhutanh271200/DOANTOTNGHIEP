using System;

namespace API.Gateways.Models
{
    public class ScheduleDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public Guid TeacherSubjectId { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public int TotalPeriod { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}