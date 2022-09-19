using Service.Core.Models.CRM;
using System;
using System.Collections.Generic;

namespace API.Gateways.Models
{
    public class HomeDashboardDTO
    {
        public Dictionary<string, string> Card { get; set; }
        public Dictionary<Day, ScheduleData> Schedules { get; set; }

        public List<Message> Messages { get; set; }

        public List<Notification> Notifications { get; set; }
    }
    public enum Day
    {
        MONDAY = 0,
        TUESDAY = 1,
        WEDNESDAY = 2,
        THURSDAY = 3,
        FRIDAY = 4,
        SATURDAY = 5
    }
    public class ScheduleData
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }

        public int TotalPeriod { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}