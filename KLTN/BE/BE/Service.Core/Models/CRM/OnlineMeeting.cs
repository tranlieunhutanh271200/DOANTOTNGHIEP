using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.CRM
{
    public class OnlineMeeting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int? TeacherSubjectId { get; set; }
        public string TeacherFullname { get; set; }
        public string SubjectName { get; set; }
        public Guid HostId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool IsStarted { get; set; }
        public bool IsDone => DateTime.Now > EndAt;
        public virtual ICollection<MeetingAttendee> Attendees { get; set; }
        public OnlineMeeting()
        {
            Attendees = new List<MeetingAttendee>();
        }
    }
}
