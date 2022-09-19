using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Gateways.Models
{
    public class VideoScriptDTO: ScriptBaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public Guid VideoId { get; set; }
    }
}
