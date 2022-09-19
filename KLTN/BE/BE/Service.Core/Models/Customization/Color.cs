using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Customization
{
    public class Color
    {
        [Key]
        public Guid AccountId { get; set; }
        public string ForeColor { get; set; }
        public string BackColor { get; set; }
        public string CardColor { get; set; }
        public string TableStripColor { get; set; }
    }
}
