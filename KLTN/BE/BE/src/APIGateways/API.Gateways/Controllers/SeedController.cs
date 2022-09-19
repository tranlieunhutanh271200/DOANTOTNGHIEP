using API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Gateways.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SeedController : ControllerBase
    {
        private readonly SubjectGrpcService _subjectgRPCService;
        public SeedController(SubjectGrpcService subjectgRPCService)
        {
            _subjectgRPCService = subjectgRPCService;
        }
        [HttpPost]
        public async Task<IActionResult> SeedData([FromQuery] Guid domainId, [FromQuery] Guid accountId)
        {
            var result = await _subjectgRPCService.DoSeed(domainId, accountId);
            if (result.Result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
