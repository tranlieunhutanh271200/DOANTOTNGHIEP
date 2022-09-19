using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class TeachingHistory
    {
        [Key]
        public int Id { get; set; }
        public Guid TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }
        public int Start { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
