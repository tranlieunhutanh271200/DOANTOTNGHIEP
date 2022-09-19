using AutoMapper;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.LogWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly CRMDbContext _crmDbContext;
        private readonly IMapper _mapper;
        public TaskController(CRMDbContext crmDbContext, IMapper mapper)
        {
            _crmDbContext = crmDbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaskAsync([FromQuery] Guid accountId)
        {
            var tasks = await _crmDbContext.Tasks.Where(x => x.Project.End > DateTime.Now && x.AssigneeId == accountId).Include(x => x.Project).Include(inc => inc.LogTasks).ToListAsync();
            return Ok(_mapper.Map<List<TaskDTO>>(tasks));
        }
        [HttpPut("{id}/logwork")]
        public async Task<IActionResult> Logwork(Guid id, [FromBody] LogworkDTO logworkDTO)
        {
            if (id != logworkDTO.TaskId)
            {
                return BadRequest();
            }
            LogTask log = _mapper.Map<LogTask>(logworkDTO);
            log.TaskId = id;
            _crmDbContext.LogTasks.Add(log);
            await _crmDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}/logwork")]
        public async Task<IActionResult> Removelogwork(Guid id)
        {
            var logworks = await _crmDbContext.LogTasks.Where(x => x.TaskId == id && x.LogAt.Date == DateTime.Now.Date).ToListAsync();
            _crmDbContext.LogTasks.RemoveRange(logworks);
            await _crmDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {
            var task = await _crmDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpGet("check")]
        public async Task<IActionResult> CheckTaskOwnerAsync([FromQuery] Guid taskId, [FromQuery] Guid accountId)
        {
            var task = await _crmDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);
            if (task == null)
            {
                return NotFound();
            }
            if (task.AssigneeId != accountId)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddTaskAsync([FromBody] TaskCreateDTO taskCreateDTO)
        {
            var task = _mapper.Map<Service.Core.Models.LogWork.Task>(taskCreateDTO);
            _crmDbContext.Tasks.Add(task);
            await _crmDbContext.SaveChangesAsync();
            return Ok(_mapper.Map<TaskDTO>(task));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(Guid id, [FromBody] TaskUpdateDTO taskUpdate)
        {
            if (id != taskUpdate.Id)
            {
                return BadRequest();
            }
            var task = await _crmDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            _mapper.Map(taskUpdate, task);
            await _crmDbContext.SaveChangesAsync();
            return Ok(task);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _crmDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            _crmDbContext.Tasks.Remove(task);
            await _crmDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
