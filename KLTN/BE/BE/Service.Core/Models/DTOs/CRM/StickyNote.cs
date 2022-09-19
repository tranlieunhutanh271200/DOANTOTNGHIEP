using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.DTOs.CRM
{
    public class StickyNote
    {
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Content { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Color { get; set; }
    }
}