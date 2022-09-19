using LanguageExt;
using Service.Core.Models.Identities;
using System;
using System.Threading.Tasks;

namespace Realtime.API.Persistence
{
    public interface IIdentityService
    {
        ValueTask<Option<Account>> GetAccount(Guid domainId, Guid accountId);
    }
}
