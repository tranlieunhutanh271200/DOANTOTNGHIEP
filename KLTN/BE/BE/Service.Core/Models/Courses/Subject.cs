using System;
using System.Collections.Generic;

namespace Service.Core.Models.Courses
{
    public class Subject : AuditEntity
    {
        public Guid DomainId { get; set; }
        public string CoverImageUrl { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public double PricePerCredit { get; set; }
        public int TotalPeriod { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}

