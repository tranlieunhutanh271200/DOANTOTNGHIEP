using System;

namespace Service.Core.Models.Customization
{
    public class Addon
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string ElementId { get; set; }
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
