using API.Gateways.Models;
using Newtonsoft.Json;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public class CRMService : ICRMService
    {
        private readonly HttpClient _httpClient;
        public CRMService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<bool> AssignStudentToProjectAsync(Guid projectId, Guid studentId)
        {
            return true;
        }

        public async ValueTask<bool> CheckTaskOwner(Guid taskId, Guid accountId)
        {
            var response = await _httpClient.GetAsync($"/api/check?accountId={accountId}&taskId={taskId}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            return true;
        }

        public async ValueTask<bool> CreateProjectAsync(Project projectCreate)
        {
            var content = new StringContent(JsonConvert.SerializeObject(projectCreate), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"api/project", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async ValueTask<bool> CreateStickyNote(Guid accountId, NoteDTO noteDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(noteDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"api/note?accountId={accountId}", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> CreateTaskAsync(TaskCreateDTO taskCreateDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(taskCreateDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"api/task", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> CreateTicketAsync(TicketCreateDTO ticketCreateDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(ticketCreateDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/ticket", content);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            return true;
        }

        public async ValueTask<bool> DeleteStickyNote(int noteId)
        {
            var result = await _httpClient.DeleteAsync($"/api/note/{noteId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> DeleteTaskAsync(Guid taskId)
        {
            var result = await _httpClient.DeleteAsync($"/api/task/{taskId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> DeleteTicketAsync(Guid ticketId)
        {
            var result = await _httpClient.DeleteAsync($"/api/Ticket/{ticketId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<string> GetConversations(Guid accountId)
        {
            var result = await _httpClient.GetAsync($"/api/message?accountId={accountId}");
            return await result.Content.ReadAsStringAsync();
        }

        public async ValueTask<string> GetStickyNotes(Guid accountId)
        {
            var result = await _httpClient.GetAsync($"/api/note?accountId={accountId}");
            return await result.Content.ReadAsStringAsync();
        }

        public ValueTask<TaskDTO> GetTaskAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<string> GetYourProjects(Guid accountId)
        {
            var result = await _httpClient.GetAsync($"/api/Project/account/{accountId}");
            return await result.Content.ReadAsStringAsync();
        }

        public async ValueTask<string> GetYourSuperviseTicketAsync(Guid accountId, TicketStatus status)
        {
            var result = await _httpClient.GetAsync($"/api/Ticket/supervisor/{accountId}?status={status}");
            return await result.Content.ReadAsStringAsync();
        }

        public async ValueTask<List<TaskDTO>> GetYourTasksAsync(Guid accountId, Service.Core.Models.LogWork.TaskStatus taskStatus)
        {
            var result = await _httpClient.GetAsync($"/api/Task?accountId={accountId}&status={taskStatus}");
            return JsonConvert.DeserializeObject<List<TaskDTO>>(await result.Content.ReadAsStringAsync());
        }

        public async ValueTask<string> GetYourTicketsAsync(Guid accountId, TicketStatus status)
        {
            var result = await _httpClient.GetAsync($"/api/Ticket/owner/{accountId}?status={status}");
            return await result.Content.ReadAsStringAsync();
        }
        public async ValueTask<string> GetNewestMessage(Guid accountId)
        {
            var result = await _httpClient.GetAsync($"/api/message/realtime?accountId={accountId}");
            return await result.Content.ReadAsStringAsync();
        }
        public async ValueTask<bool> SeenMessage(int id, Guid accountId)
        {
            var result = await _httpClient.PutAsync($"api/message/{id}?accountId={accountId}", null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> SendMessage(int conversationId, SendMessageDTO sendMessageDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(sendMessageDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"api/message/{conversationId}/send", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public ValueTask<bool> UnsentMessage(int conversationId, int messageId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> UpdateStickyNote(int noteId, NoteDTO noteDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(noteDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"/api/note/{noteId}", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> UpdateTaskAsync(Guid taskId, TaskUpdateDTO taskUpdateDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(taskUpdateDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/Task/{taskId}", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> UpdateTicketAsync(Guid ticketId, TicketUpdateDTO ticketUpdate)
        {
            var content = new StringContent(JsonConvert.SerializeObject(ticketUpdate), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/Ticket/{ticketId}", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<string> GetNewestNotification(Guid accountId)
        {
            var result = await _httpClient.GetAsync($"api/notify?accountId={accountId}");
            return await result.Content.ReadAsStringAsync();
        }

        public async ValueTask<bool> SeenNotification(Guid accountId, int notificationId)
        {
            var result = await _httpClient.PutAsync($"api/notify/{notificationId}?accountId={accountId}", null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> SeenNotification(Guid accountId)
        {
            var result = await _httpClient.PutAsync($"api/notify?accountId={accountId}", null);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> SendNotification(NotificationDTO notification)
        {
            var content = new StringContent(JsonConvert.SerializeObject(notification), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/notification", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> UpdateProjectAsync(Project projectUpdate)
        {
            var content = new StringContent(JsonConvert.SerializeObject(projectUpdate), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/project/{projectUpdate.Id}", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> DeleteProjectAsync(Guid projectId)
        {
            var result = await _httpClient.DeleteAsync($"api/project/{projectId}");
            return result.IsSuccessStatusCode;
        }

        public async ValueTask<string> GetOwnProjects(Guid accountId, int subjectId)
        {
            var result = await _httpClient.GetAsync($"api/project/owner/{accountId}?subjectId={subjectId}");
            return await result.Content.ReadAsStringAsync();
        }

        public async ValueTask<bool> LogWork(Guid taskId, LogworkDTO logwork)
        {
            var content = new StringContent(JsonConvert.SerializeObject(logwork), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/Task/{taskId}/logwork", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> ResetLogwork(Guid taskId)
        {
            var result = await _httpClient.DeleteAsync($"api/Task/{taskId}/logwork");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
