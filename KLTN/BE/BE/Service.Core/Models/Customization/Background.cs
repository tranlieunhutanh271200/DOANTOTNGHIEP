using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Customization
{
    public class Background
    {
        [Key]
        public Guid AccountId { get; set; }
        public string BackgroundImage { get; set; }
    }
}
