using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public int BaremId { get; set; }
        [ForeignKey(nameof(BaremId))]
        public virtual BaremScore Barem { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
        public double Value { get; set; }
    }
}