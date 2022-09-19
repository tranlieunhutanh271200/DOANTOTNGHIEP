using System;

namespace API.Gateways.Models
{
    public abstract class BaseDTO
    {
        public Guid DomainId { get; set; }
        public ActionDTO Action { get; set; }
    }
}