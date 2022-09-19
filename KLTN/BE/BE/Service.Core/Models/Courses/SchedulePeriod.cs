using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class SchedulePeriod
    {
        public Guid ScheduleId { get; set; }
        [ForeignKey(nameof(ScheduleId))]
        public virtual SubjectSchedule Schedule { get; set; }
        public Guid PeriodId { get; set; }
        [ForeignKey(nameof(PeriodId))]
        public virtual Period Period { get; set; }
    }
}
