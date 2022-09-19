using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.CRM
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public Guid CallerId { get; set; }
        public Guid AttendeeId { get; set; }
        public DateTime CheckAt { get; set; }
        public string Comment { get; set; }
    }
}
