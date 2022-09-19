using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.CRM
{
    public class Survey
    {
        [Key]
        public Guid DomainId { get; set; }

        public bool Flag { get; set; }
    }
}