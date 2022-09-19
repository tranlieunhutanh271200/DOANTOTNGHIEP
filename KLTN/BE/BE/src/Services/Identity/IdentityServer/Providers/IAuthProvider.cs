using IdentityServer.Models.Dtos;

namespace IdentityServer.Providers
{
    public interface IAuthProvider
    {
        IAuthResponse Auth();
    }
}
