using Microsoft.AspNetCore.Http;

namespace API.Gateways.Models
{
    public class CRUDScript
    {
        public int Action { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string ScriptType { get; set; }
        public int MyProperty { get; set; }
    }
}
