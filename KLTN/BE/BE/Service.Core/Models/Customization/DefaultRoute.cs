using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Customization
{
    public class DefaultRoute
    {
        [Key]
        public Guid AccountId { get; set; }
        public string Route { get; set; }
    }
}
