using System;

namespace Service.Core.Models.Courses
{
    public class DocumentScript : SectionScript
    {
        public string DocumentTitle { get; set; }
        public string DocumentPassword { get; set; }
        public string DocumentUrl { get; set; }
        public Guid FileId { get; set; }
        public string FileType { get; set; }
    }
}
