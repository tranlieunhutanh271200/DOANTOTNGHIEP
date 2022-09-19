using System;

namespace API.Gateways.Models
{
    public class CRUDSubject : BaseDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
    }
}
