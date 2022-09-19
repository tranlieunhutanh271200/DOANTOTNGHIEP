using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Realtime.API.Hubs;
using Realtime.API.Models;
using Realtime.API.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Realtime.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hub;
        public MeetingController(IHubContext<MessageHub> hub)
        {
            _hub = hub;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> StartMeeting()
        {
            return Ok();
        }
        [HttpPost("call/{id}")]
        public async Task<IActionResult> Call([FromRoute] Guid id,[FromBody] AttendeesDTO attendeesDTO)
        {
            var attendees = UserManager.OnlineUsers.Where(x => attendeesDTO.Attendees.Any(a => a == x.Key.AccountId)).ToList();
            MeetingDetail meetingDetail = new MeetingDetail()
            {
                HostId = attendeesDTO.HostId,
                MeetingId = id,
                HostConnectionId = UserManager.OnlineUsers.Where(x => x.Key.AccountId == attendeesDTO.HostId).FirstOrDefault().Value?.ConnectionId ?? "empty",
                SubjectName = attendeesDTO.SubjectName,
            };
            MeetingManager.AddMeeting(id, meetingDetail);
            foreach (var attendee in attendees)
            {
                await _hub.Clients.Client(attendee.Value.ConnectionId).SendAsync("calling", new {
                    meetingId = id,
                    subjectName = attendeesDTO.SubjectName,
                    teacherFullname = attendeesDTO.TeacherFullname,
                    duration = attendeesDTO.Duration,
                    teacherSubjectId = attendeesDTO.TeacherSubjectId,
                });
            }
            return Ok();
        }
    }
}