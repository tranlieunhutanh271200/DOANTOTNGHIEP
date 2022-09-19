using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Courses
{
    public class Grade
    {
        [Key]
        public Guid DomainId { get; set; }
        public string GradeName { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
