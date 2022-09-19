using Service.Core.Models.Tickets;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.CRM
{
    public class AccessoryBook
    {
        [Key]
        public int Id { get; set; }
        public int AccessoryId { get; set; }
        public virtual Accessory Accessory { get; set; }
        public Guid TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public virtual Ticket Ticket { get; set; }

        public Guid TeacherId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}