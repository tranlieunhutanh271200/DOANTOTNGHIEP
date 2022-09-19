using Service.Core.Models.Tickets;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.CRM
{
    public class StudentAbsent
    {
        public int Id { get; set; }
        public Guid DomainId { get; set; }

        public Guid StudentId { get; set; }

        public DateTime OffDate { get; set; }
        public Guid TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public virtual Ticket Ticket { get; set; }
    }
}