using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class SectionScript
    {
        public int Id { get; set; }
        public Guid SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public virtual SubjectSection Section { get; set; }
        public int Order { get; set; }
    }
}
