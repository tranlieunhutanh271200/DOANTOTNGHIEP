using System;

namespace CRM.API.Models
{
    public class LogworkDetailDTO
    {
        public DateTime LogAt { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}