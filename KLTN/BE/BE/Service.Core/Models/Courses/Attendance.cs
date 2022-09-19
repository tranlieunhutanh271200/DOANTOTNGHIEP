using System;

namespace Service.Core.Models.Courses
{
    public class Attendance
    {
        public DateTime AttendanceAt { get; set; }
        public Guid StudentId { get; set; }
    }
}
