using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ResourceService : IResourceService
    {
        private readonly HttpClient _httpContext;
        public ResourceService(HttpClient httpContext)
        {
            _httpContext = httpContext;
        }
        public async ValueTask<bool> RegisterDomainResource(Guid domainId)
        {
            var result = await _httpContext.PostAsync($"/api/DomainDirectory/{domainId}", null);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> RemoveDomainResource(Guid domainId)
        {
            var result = await _httpContext.DeleteAsync($"/api/DomainDirectory/domain/{domainId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}