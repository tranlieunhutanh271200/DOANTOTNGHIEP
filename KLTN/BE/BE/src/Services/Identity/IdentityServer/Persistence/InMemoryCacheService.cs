using Microsoft.Extensions.Configuration;
using Service.Core.Caches;

namespace IdentityServer.Persistence
{
    public class InMemoryCacheService : CacheBase, ICacheService
    {
        public InMemoryCacheService(IConfiguration configuration)
        {
            _isExpired = true;
            _expiredTime = int.Parse(configuration.GetSection("JwtSettings:TokenLifeTime").Value);
        }
    }
}
