using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.LogWork;
using System;
using System.Collections.Generic;

namespace API.Gateways.Models
{
    public class LogworkPageDTO
    {
        public List<TaskDTO> Tasks { get; set; }
        public Dictionary<TaskStatus, double> Graph;
        public Dictionary<DateTime, int> LogworkResult { get; set; }
    }
}