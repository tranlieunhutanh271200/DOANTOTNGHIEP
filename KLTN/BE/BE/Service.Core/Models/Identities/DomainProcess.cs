using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Identities
{
    public class DomainProcess
    {
        [Key]
        public int Id { get; set; }
        public Guid DomainId { get; set; }
        [ForeignKey(nameof(DomainId))]
        public virtual Domain Domain { get; set; }
        public string ToEmail { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        public virtual Account Sender { get; set; }
    }
}
