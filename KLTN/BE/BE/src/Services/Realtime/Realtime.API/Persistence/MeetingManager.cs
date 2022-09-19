using Realtime.API.Models;
using Service.Core.Models.CRM;
using System;
using System.Collections.Generic;

namespace Realtime.API.Persistence
{
    public static class MeetingManager
    {
        public static Dictionary<Guid, MeetingDetail> _meetings = new Dictionary<Guid, MeetingDetail>();

        public static bool AddMeeting(Guid meetingId, MeetingDetail meeting)
        {
            return _meetings.TryAdd(meetingId, meeting);
        }
        public static void RequestToJoin(Guid meetingId, string connectionId, Guid rtcId, RTCConnectDTO rTCConnectDTO)
        {
            if(_meetings.TryGetValue(meetingId, out var meeting)){
                MeetingMember member = new MeetingMember
                {
                    AccountId = rTCConnectDTO.AccountId,
                    FullName = rTCConnectDTO.FullName,
                    StudentID = rTCConnectDTO.StudentID,
                    IsMicOn = rTCConnectDTO.IsMicOn,
                    IsCamOn = rTCConnectDTO.IsCamOn,
                    ConnectionId = connectionId,
                    IsWaiting = true,
                    RTCId = rtcId,
                };
                meeting.Members.Add(member);
            }
        }
        public static bool RemoveMeeting(Guid meetingId)
        {
            return _meetings.Remove(meetingId);
        }
    }
}