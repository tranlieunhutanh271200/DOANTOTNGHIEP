using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Realtime.API.Hubs;
using Realtime.API.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Realtime.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hub;
        public MessageController(IHubContext<MessageHub> hub)
        {
            _hub = hub;
        }
        [HttpGet("send")]
        public async Task<IActionResult> SendMessage([FromQuery] Guid receiverId)
        {
            var receivers = UserManager.GetAccount(receiverId);
            if (receivers.Count > 0)
            {
                foreach (var receiver in receivers)
                {
                    await _hub.Clients.Client(receiver.ConnectionId).SendAsync("newmessage");
                }

            }
            return Ok();
        }
        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh([FromQuery] Guid domainId)
        {
            if (domainId == Guid.Empty)
            {
                foreach (var user in UserManager.OnlineUsers)
                {

                    await _hub.Clients.Client(user.Value.ConnectionId).SendAsync("refresh");
                }
            }
            else
            {
                foreach (var user in UserManager.OnlineUsers.Where(x => x.Value.DomainId == domainId))
                {
                    await _hub.Clients.Client(user.Value.ConnectionId).SendAsync("refresh");
                }
            }

            return Ok();
        }
    }
}