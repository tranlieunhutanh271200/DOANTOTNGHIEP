using System;

namespace IdentityServer.Models.Dtos
{
    public class RefreshTokenRequest
    {
        public Guid DomainId { get; set; }
        public Guid AccountId { get; set; }
        public string RefreshToken { get; set; }
    }
}