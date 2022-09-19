using Microsoft.AspNetCore.Http;
using Service.Core.Models.Identities;
using Service.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.Repositories
{
    public interface IDomainRepository : IAsyncRepository<Domain, Guid>
    {
        ValueTask<Domain> ModifiedComponent(Guid domainId, Guid componentId);
        ValueTask<Domain> ImportAccounts(Guid domainId, IFormFile importFile);
        ValueTask<Domain> CreateSampleDomain(Domain domain);
        ValueTask<IEnumerable<Domain>> GetDomainsAsync();
        ValueTask<Domain> GetDomainAsync(Guid domainId);
        ValueTask<Domain> GetDomainAsync(string domainName);
        ValueTask<Domain> ChangeDomainStatus(Guid domainId, DomainStatus status);
    }
}
