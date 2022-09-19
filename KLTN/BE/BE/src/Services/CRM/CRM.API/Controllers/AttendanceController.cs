using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AttendanceController : ControllerBase
    {
        public AttendanceController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid classId)
        {
            if (classId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
