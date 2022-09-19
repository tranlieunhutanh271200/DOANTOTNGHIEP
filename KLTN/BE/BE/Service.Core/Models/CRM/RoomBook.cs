using Service.Core.Models.Tickets;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.CRM
{
    public class RoomBook
    {
        [Key]
        public int Id { get; set; }
        public Guid DomainId { get; set; }
        public Guid TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public virtual Ticket Ticket { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}