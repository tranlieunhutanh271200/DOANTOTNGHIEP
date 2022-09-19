using System;

namespace API.Gateways.Models
{
    public class ScriptBaseDTO
    {
        public int Id { get; set; }
        public Guid SectionId { get; set; }
        public int Action { get; set; }
        public int Order { get; set; }
    }
}
