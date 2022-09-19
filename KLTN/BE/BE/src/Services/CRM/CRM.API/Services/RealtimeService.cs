using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRM.API.Services
{
    public class RealtimeService : IRealtimeService
    {
        private readonly HttpClient _httpClient;
        public RealtimeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<bool> SendMessage(Guid receiverId)
        {
            var result = await _httpClient.GetAsync($"/api/message/send?receiverId={receiverId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async ValueTask<bool> PushNotify(Guid accountId)
        {
            var result = await _httpClient.PostAsync($"/api/notify?accountId={accountId}", null);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> StartMeeting(Guid meetingId, Guid hostId, List<Guid> attendees, string subjectName, string teacherFullname,int teacherSubjectId, int duration)
        {
            var data = new
            {
                attendees = attendees,
                hostId = hostId,
                subjectName = subjectName,
                teacherFullname = teacherFullname,
                duration = duration,
                teacherSubjectId = teacherSubjectId
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"/api/meeting/call/{meetingId}", content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}