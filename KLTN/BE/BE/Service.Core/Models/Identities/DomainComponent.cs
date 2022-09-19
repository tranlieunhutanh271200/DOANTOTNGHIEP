using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Identities
{
    public class DomainComponent
    {
        public Guid DomainId { get; set; }
        [ForeignKey(nameof(DomainId))]
        public virtual Domain Domain { get; set; }
        public Guid ComponentId { get; set; }
        [ForeignKey(nameof(ComponentId))]
        public virtual Component Component { get; set; }
    }
}
