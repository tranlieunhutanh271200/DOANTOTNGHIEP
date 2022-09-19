using System;
using System.Threading.Tasks;

namespace Course.gRPC.Services
{
    public interface IIdentityService
    {
        ValueTask<bool> DeleteAccount(Guid accountId);
        ValueTask<bool> CreateAccount(Guid accountId, string username, string password, Guid domainId, string email);
    }
}