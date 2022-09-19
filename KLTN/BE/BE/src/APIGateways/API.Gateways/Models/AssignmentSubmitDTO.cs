using Microsoft.AspNetCore.Http;
using System;

namespace API.Gateways.Models
{
    public class AssignmentSubmitDTO
    {
        public int AssignmentId { get; set; }
        public Guid AccountId { get; set; }
        public IFormFile File { get; set; }
    }
}
