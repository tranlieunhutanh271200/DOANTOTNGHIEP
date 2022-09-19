using Service.Core.Models.Tickets;
using System;

namespace Service.Core.Models.DTOs.CRM
{
    public class TicketUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid OwnerId { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime ToDate { get; set; }
        public string Detail { get; set; }
        public Guid SupervisorId { get; set; }
        public bool IsApproved { get; set; }
        public string Status { get; set; }
    }
}
