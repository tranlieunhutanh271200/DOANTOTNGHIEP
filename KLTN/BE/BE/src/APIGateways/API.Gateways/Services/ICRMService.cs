using API.Gateways.Models;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public interface ICRMService
    {
        ValueTask<bool> CheckTaskOwner(Guid taskId, Guid accountId);
        ValueTask<List<TaskDTO>> GetYourTasksAsync(Guid accountId, Service.Core.Models.LogWork.TaskStatus taskStatus);
        ValueTask<string> GetYourProjects(Guid accountId);
        ValueTask<string> GetOwnProjects(Guid accountId, int subjectId);
        ValueTask<bool> CreateProjectAsync(Project projectCreate);
        ValueTask<bool> UpdateProjectAsync(Project projectUpdate);
        ValueTask<bool> DeleteProjectAsync(Guid projectId);
        ValueTask<bool> AssignStudentToProjectAsync(Guid projectId, Guid studentId);
        ValueTask<TaskDTO> GetTaskAsync(Guid taskId);
        ValueTask<bool> CreateTaskAsync(TaskCreateDTO taskCreateDTO);
        ValueTask<bool> UpdateTaskAsync(Guid taskId, TaskUpdateDTO taskUpdateDTO);
        ValueTask<bool> DeleteTaskAsync(Guid taskId);

        ValueTask<string> GetYourTicketsAsync(Guid accountId, TicketStatus status);
        ValueTask<string> GetYourSuperviseTicketAsync(Guid accountId, TicketStatus status);
        ValueTask<bool> CreateTicketAsync(TicketCreateDTO ticketCreateDTO);
        ValueTask<bool> UpdateTicketAsync(Guid ticketId, TicketUpdateDTO ticketUpdate);
        ValueTask<bool> DeleteTicketAsync(Guid ticketId);
        ValueTask<bool> LogWork(Guid taskId, LogworkDTO logwork);
        ValueTask<bool> ResetLogwork(Guid taskId);

        ValueTask<string> GetConversations(Guid accountId);
        ValueTask<string> GetNewestMessage(Guid accountId);
        ValueTask<string> GetNewestNotification(Guid accountId);
        ValueTask<bool> SendNotification(NotificationDTO notification);
        ValueTask<bool> SeenNotification(Guid accountId);
        ValueTask<bool> SeenNotification(Guid accountId, int notificationId);
        ValueTask<bool> SeenMessage(int id, Guid accountId);
        ValueTask<bool> SendMessage(int conversationId, SendMessageDTO sendMessageDTO);

        ValueTask<bool> UnsentMessage(int conversationId, int messageId);

        ValueTask<string> GetStickyNotes(Guid accountId);
        ValueTask<bool> CreateStickyNote(Guid accountId, NoteDTO noteDTO);
        ValueTask<bool> UpdateStickyNote(int noteId, NoteDTO noteDTO);
        ValueTask<bool> DeleteStickyNote(int noteId);
    }
}
