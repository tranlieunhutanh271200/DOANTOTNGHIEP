using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class MeetingDTO
    {
        public string Title { get; set; }
        public int TeacherSubjectId { get; set; }
        public Guid HostId { get; set; }
        public DateTime StartAt { get; set; }
        public int Duration { get; set; }
        public string TeacherFullname { get; set; }
        
        public string SubjectName { get; set; }
        
        public List<AttendeeDTO> Attendees { get; set; }


    }
}