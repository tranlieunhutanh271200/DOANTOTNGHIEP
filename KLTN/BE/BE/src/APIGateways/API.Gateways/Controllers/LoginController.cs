using API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Models.Consts;
using Service.Core.Models.DTOs.Gateway;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Http;
using System.Threading.Tasks;

namespace API.Gateways.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly SubjectGrpcService _subjectGrpcService;
        public LoginController(IIdentityService identityService, SubjectGrpcService subjectGrpcService)
        {
            _identityService = identityService;
            _subjectGrpcService = subjectGrpcService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromQuery] string returnUrl, [FromBody] LoginDTO loginDTO)
        {
            AuthenticateDTO loginAccount = await _identityService.Login(loginDTO.Domain, loginDTO.Username, loginDTO.Password);
            if (loginAccount.Account == null)
            {
                return Unauthorized();
            }
            if (loginAccount.Account.Role == RoleConst.STUDENT)
            {
                loginAccount.Data = await _subjectGrpcService.GetStudent(loginAccount.Account.Id);
            }
            if (loginAccount.Account.Role == RoleConst.TEACHER)
            {
                loginAccount.Data = await _subjectGrpcService.GetTeacher(loginAccount.Account.Id);
            }
            return HttpResponse.OK<AuthenticateDTO, IActionResult>(Ok, "Login", loginAccount, null);
        }
        [HttpGet]
        public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
        {
            return HttpResponse.OK<AuthenticateDTO, IActionResult>(Ok, "Refreshed", null, null);
        }
    }
}
