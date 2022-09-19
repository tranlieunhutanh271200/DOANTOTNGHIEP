using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realtime.API.Models
{
    public class AttendeesDTO
    {
        public List<Guid> Attendees { get; set; }
        public string Title { get; set; }
        public string SubjectName { get; set; }
        public string TeacherFullname { get; set; }
        public Guid HostId { get; set; }
        public int Duration { get; set; }
        public int TeacherSubjectId { get; set; }
    }
}