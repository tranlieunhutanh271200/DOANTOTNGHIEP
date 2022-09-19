using System;

namespace API.Gateways.Models
{
    public class DocumentScriptDTO : ScriptBaseDTO
    {
        public string DocumentTitle { get; set; }
        public string DocumentUrl { get; set; }
        public Guid FileId { get; set; }
        public string FileType { get; set; }
    }
}
