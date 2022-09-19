using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Models.Courses
{
    public class StudentCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Session => $"{StartYear} - {EndYear}";
        public Guid DomainId { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
