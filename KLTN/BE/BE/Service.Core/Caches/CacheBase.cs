using Microsoft.Extensions.Caching.Memory;
using Service.Core.Object;
using System;

namespace Service.Core.Caches
{
    public abstract class CacheBase
    {
        private IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions
        {
            ExpirationScanFrequency = TimeSpan.FromMinutes(30),
        });
        protected bool _isRedis { get; set; }
        protected string _redisUrl { get; set; }
        protected bool _isExpired { get; set; }
        protected int _expiredTime { get; set; } = 86400;
        protected string CacheName => GetType().Name;
        public void Set<T>(string key, T value)
        {

            if (_isExpired)
            {
                CacheObject<T> cacheObject = new CacheObject<T>()
                {
                    AbsoluteTimeOut = DateTime.Now.AddMilliseconds(_expiredTime),
                    Value = value
                };
                _cache.Set(key, cacheObject);
            }
            else
            {
                _cache.Set(key, value);
            }
        }
        public void Set(string key, string value)
        {
            if (_isExpired)
            {
                CacheObject<string> cacheObject = new CacheObject<string>()
                {
                    AbsoluteTimeOut = DateTime.Now.AddMilliseconds(_expiredTime),
                    Value = value
                };
                _cache.Set(key, cacheObject);
            }
            else
            {
                _cache.Set(key, value);
            }

        }
        private void Remove(string key)
        {
            _cache.Remove(key);
        }
        public T Get<T>(string key)
        {
            if (_isExpired)
            {
                if (_cache.TryGetValue(key, out CacheObject<T> cacheObject))
                {
                    if (cacheObject.AbsoluteTimeOut > DateTime.Now) //Expire date for item in cache < current date = cache still available
                    {
                        return cacheObject.Value;
                    }
                    Remove(key);
                    return default(T);
                }
                return default(T);
            }
            else
            {
                if (_cache.TryGetValue(key, out T value))
                {
                    return value;
                }
                return default(T);
            }
        }
        public string Get(string key)
        {
            if (_isExpired)
            {
                if (_cache.TryGetValue(key, out CacheObject<string> cacheObject))
                {
                    if (cacheObject.AbsoluteTimeOut > DateTime.Now) //Expire date for item in cache < current date = cache still available
                        return cacheObject.Value;
                    Remove(key);
                    return string.Empty;
                }
                return string.Empty;
            }
            else
            {
                if (_cache.TryGetValue(key, out string value))
                {
                    return value;
                }
                return string.Empty;
            }
        }
    }
}
