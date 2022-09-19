using Microsoft.AspNetCore.Mvc;
using Resource.API.Models;
using Resource.API.Persistences;
using System.Threading.Tasks;

namespace Resource.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] Mail mail)
        {
            try
            {
                MailService.SendMail(mail.To, mail.Fullname, mail.Title, mail.Body);
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}