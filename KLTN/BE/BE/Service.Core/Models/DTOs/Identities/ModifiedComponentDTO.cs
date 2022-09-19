using System;

namespace Service.Core.Models.DTOs.Identities
{
    public class ModifiedComponentDTO
    {
        public Guid DomainId { get; set; }
        public Guid ComponentId { get; set; }
        public ModifiedType ModifiedType { get; set; }
    }
    public enum ModifiedType
    {
        ADDED,
        REMOVED
    }
}
