using Microsoft.AspNetCore.SignalR;
using Realtime.API.Persistence;
using System;
using System.Threading.Tasks;

namespace Realtime.API.Hubs
{
    public class RTCHub : Hub
    {
        private IIdentityService _identityHttpClient;
        public RTCHub(IIdentityService identityHttpClient)
        {
            _identityHttpClient = identityHttpClient;
        }
        public async Task RtcConnect()
        {
            var userId = Guid.NewGuid();
            await Clients.Client(Context.ConnectionId).SendAsync("Connect", userId);
            UserManager.AddUser(userId, new Models.OnlineUser()
            {
                ConnectionId = Context.ConnectionId
            });
        }
        public async Task RequestToJoin(Guid meetingId)
        {

        }
        public override async Task OnConnectedAsync()
        {
            var user = Context.User.Identity.Name;

        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {

        }
    }
}
