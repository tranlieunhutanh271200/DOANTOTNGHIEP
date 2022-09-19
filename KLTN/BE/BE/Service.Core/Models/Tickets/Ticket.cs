using Service.Core.Models.CRM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Tickets
{
    public class Ticket : AuditEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string OwnerUsername { get; set; }
        public string OwnerFullname { get; set; }
        public string OwnerCurrentClass { get; set; }
        public string OwnerYourClass { get; set; }
        public string OwnerClass { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Detail { get; set; }
        [Required]
        public Guid SupervisorId { get; set; }
        public bool IsApproved { get; set; }
        public TicketStatus Status { get; set; }
        public bool IsHistory { get; private set; }
        public bool IsRoot { get; private set; }
        public Guid? RootId { get; set; }
        public virtual Ticket Root { get; set; }
        public virtual ICollection<Ticket> Histories { get; set; }
        public virtual ICollection<TicketComment> Comments { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
        public virtual ICollection<ReferenceReceiver> ReferenceReceivers { get; set; }
        public virtual RoomBook RoomBook { get; set; }
        public virtual StudentAbsent StudentAbsent { get; set; }
        public virtual AccessoryBook AccessoryBook { get; set; }
    }
}
