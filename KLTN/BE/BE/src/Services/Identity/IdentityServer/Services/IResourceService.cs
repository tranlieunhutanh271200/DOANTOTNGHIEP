using System;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IResourceService
    {
        ValueTask<bool> RegisterDomainResource(Guid domainId);
        ValueTask<bool> RemoveDomainResource(Guid domainId);
    }
}