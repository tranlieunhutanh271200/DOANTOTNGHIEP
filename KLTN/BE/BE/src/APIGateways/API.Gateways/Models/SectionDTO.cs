using System;

namespace API.Gateways.Models
{
    public class SectionDTO : BaseDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string RootId { get; set; }
        public int TeacherSubjectId { get; set; }
    }
}
