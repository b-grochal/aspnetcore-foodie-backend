using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Cache
{
    public interface ICacheKeyGenerator
    {
        string GenerateCacheKey(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters);
    }

    public class CacheKeyGenerator : ICacheKeyGenerator, IDisposable
    {
        private readonly SHA256 sha256;

        public CacheKeyGenerator()
        {
            this.sha256 = SHA256.Create();
        }

        public string GenerateCacheKey(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters)
        {
            var cacheKey = PrepareKey(cachePrefix, methodName, parameters);
            return HashKey(cacheKey);
        }

        public void Dispose()
        {
            sha256.Dispose();
        }

        private string PrepareKey(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters)
        {
            StringBuilder cacheKey = new StringBuilder();
            cacheKey.Append($"{cachePrefix}-{methodName}");
            
            foreach (string parameter in parameters)
            {
                cacheKey.Append($"-{parameter}");
            }

            return cacheKey.ToString();
        }

        private string HashKey(string key)
        {
            byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            return Convert.ToHexString(hashValue);
        }
    }
}
