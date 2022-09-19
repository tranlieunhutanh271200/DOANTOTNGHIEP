using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.CRM
{
    public class Accessory
    {
        [Key]
        public int Id { get; set; }

        public Guid DomainId { get; set; }
        public Guid ImageId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public DateTime DateIn { get; set; }
        public bool IsBooked { get; set; }
        public virtual ICollection<AccessoryBook> BookHistories { get; set; }
    }
}