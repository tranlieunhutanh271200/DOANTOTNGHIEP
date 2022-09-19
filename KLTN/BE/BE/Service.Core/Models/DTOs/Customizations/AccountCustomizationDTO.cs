using Service.Core.Models.Customization;
using System.Collections.Generic;

namespace Service.Core.Models.DTOs.Customizations
{
    public class AccountCustomizationDTO
    {
        public List<Addon> Addons { get; set; }
        public bool IsCollapsed { get; set; }
        public bool IsCustomized { get; set; }
        public string BackgroundImage { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
        public string CardColor { get; set; }
        public string TableStripColor { get; set; }
        public string Route { get; set; }
    }
}
