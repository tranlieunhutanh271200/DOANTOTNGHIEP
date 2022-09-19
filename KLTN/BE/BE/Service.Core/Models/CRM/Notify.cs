using System;

namespace Service.Core.Models.CRM
{
    public class Notify
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSeen { get; set; }
        public string CreateAt { get => CreatedAt.ToString("dd-MM-yyyy"); }
    }
}