using System.Collections.Generic;

namespace Service.Core.Models.Identities
{
    public class Component : AuditEntity
    {
        public string ComponentName { get; set; }
        public string ComponentEndpoint { get; set; }
        public string ComponentLogo { get; set; }
        public double Price { get; set; }
        public bool IsFree => Price == 0;
        public virtual ICollection<DomainComponent> Domains { get; set; }
    }
}
