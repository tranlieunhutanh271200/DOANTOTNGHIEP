using Microsoft.AspNetCore.SignalR;
using Realtime.API.Models;
using Realtime.API.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Realtime.API.Hubs
{
    public class MessageHub : Hub
    {
        private readonly IIdentityService _identityService;
        public MessageHub(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task GetWaitingRequest()
        {

        }
        public async Task RTCConnect(RTCConnectDTO rtcConnect)
        {
            var userId = Guid.NewGuid();
            await Clients.Client(Context.ConnectionId).SendAsync("Connect", userId);


            MeetingManager.RequestToJoin(rtcConnect.MeetingId, Context.ConnectionId, userId, rtcConnect);
        }
        public void ChatConnect(MessageConnectDTO connectDTO)
        {
            if (!UserManager.OnlineUsers.Any(x => x.Key.AccountId == connectDTO.AccountId && x.Key.ConnectionId == Context.ConnectionId))
            {
                UserManager.AddUser(connectDTO.AccountId, new OnlineUser
                {
                    AccountId = connectDTO.AccountId,
                    DomainId = connectDTO.DomainId,
                    Username = connectDTO.Username,
                    ConnectionId = Context.ConnectionId,
                    Fullname = connectDTO.FullName
                });
            }
        }
        public void Logout(LogoutDTO logout)
        {
            if (!UserManager.OnlineUsers.Any(x => x.Key.AccountId == logout.AccountId && x.Key.ConnectionId == Context.ConnectionId))
            {
                UserManager.RemoveUser(logout.AccountId, Context.ConnectionId);
                System.Console.WriteLine("User logout");
            }
        }
        public override async Task OnConnectedAsync()
        {
            System.Console.WriteLine("User connected");
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = UserManager.OnlineUsers.FirstOrDefault(x => x.Key.ConnectionId == Context.ConnectionId);
            if (user.Value != null)
            {
                UserManager.RemoveUser(user.Key.AccountId, Context.ConnectionId);
                System.Console.WriteLine("User logout");
            }
        }
    }
}
