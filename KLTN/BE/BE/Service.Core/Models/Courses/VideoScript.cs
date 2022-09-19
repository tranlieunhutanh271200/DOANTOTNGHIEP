using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Models.Courses
{
    public class VideoScript: SectionScript
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public Guid VideoId { get; set; }
    }
}
