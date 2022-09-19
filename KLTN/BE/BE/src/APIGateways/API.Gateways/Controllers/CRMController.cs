using API.Gateways.Models;
using API.Gateways.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.Tickets;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

[ApiController]
[Route("api/[Controller]")]
public class CRMController : ControllerBase
{
    private readonly ICRMService _crmService;
    private readonly IMapper _mapper;
    private readonly SubjectGrpcService subjectService;
    public CRMController(ICRMService crmService, IMapper mapper, SubjectGrpcService subjectService)
    {
        _crmService = crmService;
        _mapper = mapper;
        this.subjectService = subjectService;
    }
    [HttpGet("conversations")]
    public async Task<IActionResult> GetConversations([FromQuery] Guid accountId)
    {
        //call grpc to get list teacher
        //call crm to get list message
        return Ok(await _crmService.GetConversations(accountId));
    }
    [HttpPost("conversations/{id}/send")]
    public async Task<IActionResult> SendMessage([FromRoute] int id, [FromBody] SendMessageDTO sendMessageDTO)
    {
        return Ok(await _crmService.SendMessage(id, sendMessageDTO));
    }
    [HttpPut("conversations/{id}/seen")]
    public async Task<IActionResult> SeenMessage([FromRoute] int id, [FromQuery] Guid accountId)
    {
        var result = await _crmService.SeenMessage(id, accountId);
        if (result)
        {
            return Ok();
        }
        return NoContent();
    }
    [HttpGet("conversations/realtime")]
    public async Task<IActionResult> GetRealtimeMessage([FromQuery] Guid accountId)
    {
        return Ok(await _crmService.GetNewestMessage(accountId));
    }
    [HttpGet("notification")]
    public async Task<IActionResult> GetNotification([FromQuery] Guid accountId)
    {
        return Ok(await _crmService.GetNewestNotification(accountId));
    }
    [HttpPut("notification")]
    public async Task<IActionResult> SeenNotification([FromQuery] Guid accountId)
    {
        var result = await _crmService.SeenNotification(accountId);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("notification/{id}")]
    public async Task<IActionResult> SeenNotify([FromRoute] int id, [FromQuery] Guid accountId)
    {
        var result = await _crmService.SeenNotification(accountId, id);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("project/dashboard")]
    public async Task<IActionResult> GetProjectDashboard([FromQuery] Guid accountId)
    {
        return Ok();
    }
    [HttpGet("project")]
    public async Task<IActionResult> GetYourProject([FromQuery] Guid accountId)
    {
        var result = await _crmService.GetYourProjects(accountId);
        return Ok(result);
    }
    [HttpGet("project/own/{id}")]
    public async Task<IActionResult> GetOwnProject([FromRoute] Guid id, [FromQuery] int subjectId)
    {
        var result = await _crmService.GetOwnProjects(id, subjectId);
        return Ok(result);
    }
    [HttpPost("project")]
    public async Task<IActionResult> CreateProject([FromBody] ProjectCreateDTO projectCreate)
    {
        var result = await _crmService.CreateProjectAsync(_mapper.Map<Project>(projectCreate));
        if (!result)
        {
            return BadRequest();
        }
        return Ok();
    }
    [HttpPut("project/{id}")]
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectCreateDTO projectCreate)
    {
        Project project = new Project
        {
            Id = id,
            Name = projectCreate.Name,
            Description = projectCreate.Description,
            LeaderId = projectCreate.LeaderId,
            SubjectId = projectCreate.SubjectId,
            Start = projectCreate.Start,
            End = projectCreate.End,
            OwnerId = projectCreate.OwnerId,
        };
        var result = await _crmService.UpdateProjectAsync(project);
        if (!result)
        {
            return BadRequest();
        }
        return Ok();
    }
    [HttpDelete("project/{id}")]
    public async Task<IActionResult> DeleleProject(Guid id)
    {
        var result = await _crmService.DeleteProjectAsync(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("task/{taskId}/logwork")]
    public async Task<IActionResult> Logwork(Guid taskId, [FromBody] LogworkDTO logworkDTO)
    {
        var result = await _crmService.LogWork(taskId, logworkDTO);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("task/{taskId}/logwork")]
    public async Task<IActionResult> ResetLogwork(Guid taskId)
    {
        var result = await _crmService.ResetLogwork(taskId);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost("task")]
    public async Task<IActionResult> CreateTask([FromBody] TaskCreateDTO taskCreateDTO)
    {
        var result = await _crmService.CreateTaskAsync(taskCreateDTO);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet("task")]
    public async Task<IActionResult> GetYourTasks([FromQuery] Guid accountId, [FromQuery] Service.Core.Models.LogWork.TaskStatus taskStatus = Service.Core.Models.LogWork.TaskStatus.PROCESS)
    {
        var result = await _crmService.GetYourTasksAsync(accountId, taskStatus);
        return Ok(result);
    }
    [HttpPut("task/{taskId}")]
    public async Task<IActionResult> UpdateTask([FromRoute] Guid taskId, [FromBody] TaskUpdateDTO taskUpdateDTO)
    {
        var result = await _crmService.UpdateTaskAsync(taskId, taskUpdateDTO);
        if (!result)
        {
            return BadRequest();
        }
        return Ok();
    }
    [HttpDelete("task/{taskId}")]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid taskId, [FromBody] TaskUpdateDTO taskUpdateDTO)
    {
        var result = await _crmService.DeleteTaskAsync(taskId);
        if (!result)
        {
            return BadRequest();
        }
        return Ok();
    }
    [HttpGet("ticket")]
    public async Task<IActionResult> GetYourTicket([FromQuery] Guid accountId, [FromQuery] bool isTeacher = false, [FromQuery] TicketStatus status = TicketStatus.NEW)
    {
        if (!isTeacher)
        {
            var result = await _crmService.GetYourTicketsAsync(accountId, status);
            return Ok(result);
        }
        else
        {
            var result = await _crmService.GetYourSuperviseTicketAsync(accountId, status);
            return Ok(result);
        }
    }
    [HttpPost("ticket")]
    public async Task<IActionResult> CreateTicket([FromQuery] Guid accountId, [FromBody] TicketCreateDTO ticketCreateDTO)
    {
        var result = await _crmService.CreateTicketAsync(ticketCreateDTO);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("ticket/{id}")]
    public async Task<IActionResult> UpdateTicket(Guid id, TicketUpdateDTO ticketUpdate)
    {
        var result = await _crmService.UpdateTicketAsync(id, ticketUpdate);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("ticket/{id}")]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        var result = await _crmService.DeleteTicketAsync(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("note")]
    public async Task<IActionResult> GetYourStickyNote([FromQuery] Guid accountId)
    {
        return Ok(await _crmService.GetStickyNotes(accountId));
    }
    [HttpPost("note")]
    public async Task<IActionResult> CreateNote([FromQuery] Guid accountId, [FromBody] NoteDTO note)
    {
        return Ok(await _crmService.CreateStickyNote(accountId, note));
    }
    [HttpPut("note/{id}")]
    public async Task<IActionResult> UpdateNote([FromRoute] int id, [FromBody] NoteDTO note)
    {
        return Ok(await _crmService.UpdateStickyNote(id, note));
    }
    [HttpDelete("note/{id}")]
    public async Task<IActionResult> DeleteNote([FromRoute] int id)
    {
        return Ok(await _crmService.DeleteStickyNote(id));
    }
    private async Task CreateNotification(Guid accountId, string notifyContent)
    {
        NotificationDTO notification = new NotificationDTO
        {
            AccountId = accountId,
            Content = notifyContent
        };
        var content = new StringContent(JsonConvert.SerializeObject(notification), Encoding.UTF8, "application/json");
        var result = await _crmService.SendNotification(notification);
    }
}