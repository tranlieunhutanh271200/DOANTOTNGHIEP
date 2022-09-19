using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realtime.API.Models
{
    public class RTCConnectDTO
    {
        public Guid AccountId { get; set; }
        public string FullName { get; set; }
        public string StudentID { get; set; }
        public Guid MeetingId { get; set; }
        public bool IsCamOn { get; set; }
        public bool IsMicOn { get; set; }
    }
}