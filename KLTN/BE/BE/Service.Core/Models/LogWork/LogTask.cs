using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.LogWork
{
    public class LogTask
    {
        public int Id { get; set; }
        public DateTime LogAt { get; set; } = DateTime.Now;
        public int Duration { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task Task { get; set; }
    }
}
