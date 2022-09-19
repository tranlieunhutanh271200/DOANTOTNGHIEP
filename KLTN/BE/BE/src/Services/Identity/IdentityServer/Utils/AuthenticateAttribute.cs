using System;

namespace IdentityServer.Utils
{
    public class AuthenticateAttribute : Attribute
    {
        public string Role { get; set; }
        public AuthenticateAttribute(string role)
        {
            Role = role;
        }
    }
}
