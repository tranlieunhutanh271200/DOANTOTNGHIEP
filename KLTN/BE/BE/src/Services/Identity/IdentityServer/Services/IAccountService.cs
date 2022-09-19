using IdentityServer.Models.Dtos;
using LanguageExt;
using Service.Core.Models.DTOs.Identities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IAccountService
    {
        ValueTask<bool> UpdateRefreshToken(Guid accountId, string refreshToken);
        ValueTask<List<AccountDTO>> GetAccountsAsync(Guid domainId);
        ValueTask<TokenResponseDTO> GenerateToken(string email);
        ValueTask<Option<AccountDTO>> GetAccount(Guid domainId, Guid accountId);
        ValueTask<AccountDTO> GetAccount(string domain, string username, string refreshToken);
        ValueTask<AccountDTO> GetAccount(string domain, string username);
        ValueTask<Option<AccountDTO>> Register(string email, string password);
        ValueTask<bool> CreateAccount(Guid id, string email, string username, string password, Guid domainId);
        ValueTask<bool> DeleteAccount(string email);
        ValueTask<bool> DeleteAccount(Guid accountId);
        ValueTask<bool> LockAccount(string email, TimeSpan lockTo);
        ValueTask<bool> UnlockAccount(string email);
    }
}
