using Realtime.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Realtime.API.Persistence
{
    public static class UserManager
    {
        public static Dictionary<OnlineUserKey, OnlineUser> OnlineUsers = new Dictionary<OnlineUserKey, OnlineUser>();
        public static void AddUser(Guid accountId, OnlineUser account)
        {
            if (OnlineUsers.Any(x => x.Key.AccountId == accountId && x.Key.ConnectionId == account.ConnectionId))
            {
                return;
            }
            OnlineUsers.Add(new OnlineUserKey
            {
                AccountId = accountId,
                ConnectionId = account.ConnectionId
            }, account);
        }
        public static void RemoveUser(Guid accountId, string connectionId)
        {
            if (OnlineUsers.Any(x => x.Key.AccountId == accountId && x.Key.ConnectionId == connectionId))
            {
                return;
            }
            var item = OnlineUsers.Where(x => x.Key.AccountId == accountId && x.Key.ConnectionId == connectionId).FirstOrDefault();
            if (item.Value != null)
            {
                OnlineUsers.Remove(item.Key);
            }
        }
        public static List<OnlineUser> GetAccount(Guid accountId)
        {
            return OnlineUsers.Where(x => x.Key.AccountId == accountId).Select(x => x.Value).ToList();
        }
    }
}