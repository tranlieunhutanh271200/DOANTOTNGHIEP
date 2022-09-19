using API.Gateways.Attributes;
using API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Models.Consts;
using Service.Core.Models.DTOs.Gateway;
using Service.Core.Models.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Gateways.Controllers
{
    [Route("v1/[Controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICRMService _crmService;
        private readonly SubjectGrpcService _grpcService;
        public HomeController(ICRMService crmService, SubjectGrpcService grpcService)
        {
            _crmService = crmService;
            _grpcService = grpcService;
        }
        [Identify(Role = RoleConst.STUDENT)]
        [HttpGet("{domain}/{studentId}")]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetHomeData([FromQuery] string domain, [FromQuery] Guid studentId)
        {
            return HttpResponse.OK<HomeDTO, IActionResult>(Ok, "Get home data", null, null);
        }
    }
}
