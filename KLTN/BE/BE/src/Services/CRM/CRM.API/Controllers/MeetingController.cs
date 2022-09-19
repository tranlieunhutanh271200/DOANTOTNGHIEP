using AutoMapper;
using CRM.API.Models;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.CRM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MeetingController : ControllerBase
    {
        private CRMDbContext _db;
        private readonly IMapper _mapper;
        public MeetingController(CRMDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetYourMeeting(Guid accountId)
        {
            var meetings = await _db.Meetings.Where(x => x.HostId == accountId && x.EndAt < DateTime.Now).Include(inc => inc.Attendees).ToListAsync();

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeeting([FromRoute] Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromRoute] Guid teacherId, [FromBody] MeetingDTO meetingDTO)
        {
            var meeting = _mapper.Map<OnlineMeeting>(meetingDTO);
            meeting.EndAt = meeting.StartAt.AddHours(meetingDTO.Duration);
            if (await _db.Meetings.AnyAsync(x => x.HostId == meetingDTO.HostId && x.StartAt == meetingDTO.StartAt))
            {
                return NoContent();
            }
            _db.Meetings.Add(meeting);
            if (await _db.SaveChangesAsync() > 0)
            {
                foreach (var attendee in meetingDTO.Attendees)
                {
                    await _db.Push(attendee.AccountId, $"Môn {meetingDTO.SubjectName} có lịch học online vào ngày {meetingDTO.StartAt.ToString("dd-MM-yyyy")} với thời lượng {meetingDTO.Duration} tiếng.");
                }
                return Ok();
            }
            return BadRequest(); ;
        }
        [HttpGet("start/{id}")]
        public async Task<IActionResult> StartMeeting([FromRoute] Guid id, [FromQuery] Guid hostId)
        {
            var meeting = await _db.Meetings.Where(x => x.Id == id).Include(inc => inc.Attendees).FirstOrDefaultAsync();
            if (meeting == null)
            {
                return NotFound();
            }
            if (meeting.HostId != hostId)
            {
                return Unauthorized();
            }
            meeting.IsStarted = true;
            if (await _db.Call(meeting.Attendees.Select(x => x.AttendeeId).ToList(), id, hostId, meeting.SubjectName, meeting.TeacherFullname, meeting.TeacherSubjectId.Value, (meeting.EndAt - meeting.StartAt).Hours))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}