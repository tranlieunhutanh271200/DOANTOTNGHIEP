using System;

namespace IdentityServer.Models.Dtos
{
    public class LockAccountRequestDTO
    {
        public string Email { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Status { get; set; } = false;
    }
}
