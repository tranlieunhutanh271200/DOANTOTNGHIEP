using System;

namespace Service.Core.Models.DTOs.Courses
{
    public class SectionCreateDTO
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TeacherSubjectId { get; set; }
        public Guid? RootId { get; set; }
    }
}
