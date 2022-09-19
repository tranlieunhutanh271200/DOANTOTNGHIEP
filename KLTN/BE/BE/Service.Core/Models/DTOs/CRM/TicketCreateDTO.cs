using System;

namespace Service.Core.Models.DTOs.CRM
{
    public class TicketCreateDTO
    {
        public string Title { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public string TicketType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Detail { get; set; }
        public Guid SupervisorId { get; set; }
    }
}
