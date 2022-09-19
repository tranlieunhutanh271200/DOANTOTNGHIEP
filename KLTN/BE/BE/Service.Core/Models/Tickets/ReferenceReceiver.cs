using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Tickets
{
    public class ReferenceReceiver : AuditEntity
    {
        public Guid TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public virtual Ticket Ticket { get; set; }
        public Guid ReceiverId { get; set; }
        public bool IsApproved { get; set; }
    }
}
