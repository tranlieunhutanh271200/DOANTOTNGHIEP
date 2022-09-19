using System;
using System.Collections.Generic;

namespace Realtime.API.Models
{
    public class MeetingDetail
    {
        public Guid MeetingId { get; set; }
        public Guid HostId { get; set; }
        public Guid HostRTCId { get; set; }
        public string SubjectName { get; set; }
        public string HostConnectionId { get; set; }
        public bool IsStarted { get; set; }
        public List<MeetingMember> Members { get; set; }
        public MeetingDetail()
        {
            Members = new List<MeetingMember>();
        }
    }
    public class MeetingMember
    {
        public Guid AccountId { get; set; }
        public string ConnectionId { get; set; }
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public bool IsMicOn { get; set; }
        public bool IsCamOn { get; set; }
        public bool IsWaiting { get; set; }
        public Guid RTCId { get; set; }
    }
}