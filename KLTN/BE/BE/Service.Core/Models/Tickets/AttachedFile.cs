using System;

namespace Service.Core.Models.Tickets
{
    public class AttachedFile : AuditEntity
    {
        public Guid TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}
