using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.CRM
{
    public class MeetingAttendee
    {
        [Key]
        public int Id { get; set; }
        public Guid MeetingId { get; set; }
        [ForeignKey(nameof(MeetingId))]
        public virtual OnlineMeeting Meeting { get; set; }
        public Guid AttendeeId { get; set; }
        public DateTime JoinAt { get; set; }
        public DateTime LeaveAt { get; set; }
        public DateTime LastLeaveAt { get; set; }
    }
}
