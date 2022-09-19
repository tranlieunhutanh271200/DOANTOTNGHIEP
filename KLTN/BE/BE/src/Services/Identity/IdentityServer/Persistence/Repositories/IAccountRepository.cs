using Service.Core.Models.Identities;
using Service.Core.Persistence.Interfaces;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.Repositories
{
    public interface IAccountRepository : IAsyncRepository<Account, Guid>
    {
        ValueTask<Account> GetAccount(string domain, string username, string refreshToken);
        ValueTask<Account> GetAccount(string domain, string username);
        ValueTask<Account> GetAccount(Guid accountId);
        ValueTask<Account> RegisterAccount(string username, string roleId);
        ValueTask<bool> CheckAccountExist(string domain, string username);
        ValueTask<string> GenerateToken(string domain, string username, string password);
        ValueTask<string> GenerateToken(string domain, string username);
        ValueTask<string> GenerateRefreshToken();
        ValueTask<RefreshToken> GenerateRefreshToken(string ipAddress);
        ValueTask<bool> LockAccount(string email, TimeSpan duration);
    }
}
