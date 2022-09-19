using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Services
{
    public interface IRealtimeService
    {
        ValueTask<bool> SendMessage(Guid receiverId);
        ValueTask<bool> PushNotify(Guid accountId);
        ValueTask<bool> StartMeeting(Guid meetingId, Guid hostId, List<Guid> attendees, string subjectName, string teacherFullname, int teacherSubjectId, int duration);
    }
}