using Service.Core.Models.Tickets;
using System;

namespace Service.Core.Models.DTOs.CRM
{
    public class TicketDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public string OwnerFullname { get; set; }
        public string OwnerEmail { get; set; }
        public TicketType TicketType { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CreateDate { get; set; }
        public string Detail { get; set; }
        public Guid SupervisorId { get; set; }
        public string SupervisorUsername { get; set; }
        public string SupervisorFullname { get; set; }
        public string SupervisorEmail { get; set; }
        public string Status { get; set; }
    }
}
