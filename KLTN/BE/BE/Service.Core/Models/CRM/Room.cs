using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.CRM
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid DomainId { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public bool IsLab { get; set; }

        public int TotalSeat { get; set; }
        public int TotalTV { get; set; }

        public int TotalAirCondition { get; set; }
        public bool IsFree { get; set; }

    }
}