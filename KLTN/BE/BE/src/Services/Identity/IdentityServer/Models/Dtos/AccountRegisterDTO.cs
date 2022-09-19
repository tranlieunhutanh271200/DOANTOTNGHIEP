using System;

namespace IdentityServer.Models.Dtos
{
    public class AccountRegisterDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid DomainId { get; set; }
        public string Email { get; set; }
    }
}
