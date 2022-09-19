using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Service.Core.Models.Identities;
using Service.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Persistence.Repositories
{
    public class DomainRepository : AsyncRepository<Domain, Guid>, IDomainRepository
    {
        public DomainRepository(IdentityDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public ValueTask<Domain> ChangeDomainStatus(Guid domainId, DomainStatus status)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Domain> CreateSampleDomain(Domain domain)
        {
            _dbSet.Add(domain);
            return domain;
        }

        public async ValueTask<Domain> GetDomainAsync(Guid domainId)
        {
            return await GetEntity(domainId);
        }

        public async ValueTask<Domain> GetDomainAsync(string domainName)
        {
            return await GetEntity(x => x.Abbreviation.ToLower().Equals(domainName.ToLower()));
        }

        public async ValueTask<IEnumerable<Domain>> GetDomainsAsync()
        {
            var result = await GetAllWithIncludesAsync(includes: inc => inc.Components);
            return result.ToList();
        }

        public ValueTask<Domain> ImportAccounts(Guid domainId, IFormFile importFile)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Domain> ModifiedComponent(Guid domainId, Guid componentId)
        {
            throw new NotImplementedException();
        }
    }
}
