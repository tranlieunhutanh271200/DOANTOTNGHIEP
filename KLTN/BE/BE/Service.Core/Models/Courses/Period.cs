using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Courses
{
    public class Period
    {
        [Key]
        public Guid DomainId { get; set; }
        public string PeriodName { get; set; }
        public int TotalMinute { get; set; }
        public int StartHour { get; set; }
        public int StartMin { get; set; }
        public int EndHour { get; set; }
        public int EndMin { get; set; }
    }
}
