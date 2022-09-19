using System;

namespace API.Gateways.Models
{
    public class SubjectDTO : BaseDTO
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int Credit { get; set; }
        public int PricePerCredit { get; set; }
    }
}