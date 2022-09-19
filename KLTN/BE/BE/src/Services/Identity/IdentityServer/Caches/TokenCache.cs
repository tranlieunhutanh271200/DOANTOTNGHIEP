using Service.Core.Caches;
using System;

namespace IdentityServer.Caches
{
    public class TokenCache : CacheBase
    {
        private static Lazy<TokenCache> _instance = new Lazy<TokenCache>(() => new TokenCache());
        public static TokenCache Instance => _instance.Value;
        private TokenCache()
        {
            _isRedis = false;
            _isExpired = true;
        }
    }
}
