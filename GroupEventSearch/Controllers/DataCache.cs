using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace GroupEventSearch.Controllers
{
    public class DataCache
    {
        private readonly IMemoryCache _cache;
        public DataCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public  void RemoveCachedObject(string key)
        {
            _cache.Remove(key);
        }
        public  object GetCachedObject(string key)
        {
            return _cache.Get(key);
        }

        public  void SetCachedObject(string key, object o, int durationSecs)
        {
            _cache.Set(key, o, DateTime.Now.AddSeconds(durationSecs));
        }
        public void SetCachedObjectSliding(string key, object o, int slidingSecs)
        {
            _cache.Set(key, o, new TimeSpan(slidingSecs));
        }
        public  void SetCachedObjectPermanent(string key, object o)
        {
            _cache.Remove(key);
            _cache.Set(key, o);
        }
    }
}

