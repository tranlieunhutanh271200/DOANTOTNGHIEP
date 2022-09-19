using System;

namespace API.Gateways.Models
{
    public class AssignmentScriptDTO : ScriptBaseDTO
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime DueTo { get; set; }
        public bool IsReopen { get; set; }
    }
}
