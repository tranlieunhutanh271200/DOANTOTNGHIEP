using AutoMapper;
using CRM.API.Models;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ReportController : ControllerBase
    {
        private readonly CRMDbContext _db;
        private readonly IMapper _mapper;
        public ReportController(CRMDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet("ticket")]
        public async Task<IActionResult> GenerateTicketReport([FromQuery] int classId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            return Ok();
        }
        [HttpGet("task")]
        public async Task<IActionResult> GenerateTaskReport([FromQuery] int classId, [FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var projects = await _db.Projects.Where(x => x.SubjectId == classId).Include(inc => inc.Members)
            .Include(inc => inc.Tasks).ThenInclude(inc => inc.LogTasks.Where(x => x.LogAt >= DateTime.Parse(fromDate) && x.LogAt <= DateTime.Parse(toDate))).AsSplitQuery().ToListAsync();

            var result = _mapper.Map<List<ProjectDTO>>(projects);
            return Ok(result);
        }
        [HttpGet("score")]
        public async Task<IActionResult> GenerateScoreReport([FromQuery] int classId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            return Ok();
        }
    }
}