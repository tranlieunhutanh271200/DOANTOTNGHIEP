using System;

namespace Service.Core.Models.Identities
{
    public class ProviderAuth
    {
        public Guid Id { get; set; }
        public string Provider { get; set; }
        public string Key { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
