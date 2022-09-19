using System;

namespace Service.Core.Models.Identities
{
    public class AccountToken
    {
        public Guid AccountId { get; set; }
        public string Token { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime AbsoluteExpire { get; set; }
    }
}
