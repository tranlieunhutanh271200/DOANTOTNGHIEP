using AutoMapper;
using CRM.API.Models;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly CRMDbContext _db;
        private readonly IMapper _mapper;
        public ProjectController(CRMDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProjects([FromQuery] int classId)
        {
            var projects = await _db.Projects.Where(x => x.SubjectId == classId).Include(inc => inc.Tasks).ThenInclude(x => x.LogTasks).ToListAsync();
            return Ok(projects);
        }
        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetAccountProjects([FromRoute] Guid id)
        {
            var projects = await _db.Projects.Where(x => (x.Members.Any(mem => mem.AccountId == id) || x.LeaderId == id) && x.End > DateTime.Now).Include(inc => inc.Tasks.Where(task => task.AssigneeId == id)).ToListAsync();
            return Ok(_mapper.Map<List<ProjectDTO>>(projects));
        }
        [HttpGet("owner/{id}")]
        public async Task<IActionResult> GetOwnerProject([FromRoute] Guid id, [FromQuery] int subjectId)
        {
            var projects = await _db.Projects.Where(x => x.OwnerId == id && x.SubjectId == subjectId).Include(inc => inc.Tasks).Include(inc => inc.Members).ToListAsync();
            return Ok(_mapper.Map<List<ProjectDTO>>(projects));
        }
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetProjectDashboard([FromQuery] Guid accountId)
        {

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project projectCreate)
        {
            _db.Projects.Add(projectCreate);
            await _db.SaveChangesAsync();
            return Ok();

        }
        [HttpPut("{id}/members")]
        public async Task<IActionResult> AssignMember([FromRoute] Guid id, [FromBody] List<Guid> members)
        {
            Project project = await _db.Projects.Where(x => x.Id == id).Include(inc => inc.Members).FirstOrDefaultAsync();
            var removeMembers = project.Members.Where(x => !members.Any(mem => mem == x.AccountId)).ToList();
            foreach (var member in removeMembers)
            {
                _db.Remove(member);
            }
            foreach (var member in members)
            {
                if (!project.Members.Any(x => x.AccountId == member))
                {
                    Member mem = new Member()
                    {
                        AccountId = member,
                    };

                    project.Members.Add(mem);
                }
            }
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] Project project)
        {
            var dbProject = await _db.Projects.FirstOrDefaultAsync(x => x.Id == project.Id);
            if (dbProject == null)
            {
                return NotFound();
            }
            _mapper.Map(project, dbProject);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            Project project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            _db.Remove(project);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{id}/tasks")]
        public async Task<IActionResult> GetTasks(Guid id)
        {
            var tasks = await _db.Projects.Where(x => x.Id == id).Include(inc => inc.Tasks).SelectMany(x => x.Tasks).FirstOrDefaultAsync();
            return Ok(_mapper.Map<List<TaskDTO>>(tasks));
        }
        [HttpDelete("{id}/tasks/{taskId}")]
        public async Task<IActionResult> DeleteTask(Guid id, Guid taskId)
        {
            Service.Core.Models.LogWork.Task task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);
            if (task.ProjectId != id)
            {
                return NotFound();
            }
            _db.Remove(task);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return Ok();
        }
    }
}