using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Realtime.API.Hubs;
using Realtime.API.Persistence;
using System;
using System.Threading.Tasks;

namespace Realtime.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _messageHub;
        public NotifyController(IHubContext<MessageHub> messageHub)
        {
            _messageHub = messageHub;
        }
        [HttpPost]
        public async Task<IActionResult> PostNotify([FromQuery] Guid accountId)
        {
            var onlineUsers = UserManager.GetAccount(accountId);
            if (onlineUsers.Count > 0)
            {
                foreach (var online in onlineUsers)
                {
                    await _messageHub.Clients.Client(online.ConnectionId).SendAsync("navigationrefresh");
                }
            }
            return Ok();
        }
    }
}