using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Customization
{
    public class Menu
    {
        [Key]
        public Guid AccountId { get; set; }
        public bool IsCollapsed { get; set; }
        public bool IsCustomized => Addons.Count > 0;
        public virtual ICollection<Addon> Addons { get; set; }
        public Menu()
        {
            Addons = new List<Addon>();
        }
    }
}
