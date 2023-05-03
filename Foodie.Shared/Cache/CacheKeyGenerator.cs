using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Foodie.Shared.Cache
{
    public interface ICacheKeyGenerator
    {
        string GenerateCacheKey(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters);
    }

    public class CacheKeyGenerator : ICacheKeyGenerator, IDisposable
    {
        private readonly SHA256 sha256;
        private readonly char linkingCharacter;

        public CacheKeyGenerator()
        {
            this.sha256 = SHA256.Create();
            this.linkingCharacter = '-';
        }

        public string GenerateCacheKey(CachePrefixes cachePrefix, [CallerMemberName] string methodName = "", params string[] parameters)
        {
            var key = PrepareKey(methodName, parameters);
            var hashedKey = HashKey(key);
            return $"{cachePrefix}{linkingCharacter}{hashedKey}";
        }

        public void Dispose()
        {
            sha256.Dispose();
        }

        private string PrepareKey([CallerMemberName] string methodName = "", params string[] parameters)
        {
            StringBuilder cacheKey = new StringBuilder();
            cacheKey.Append($"{methodName}");

            foreach (string parameter in parameters)
            {
                cacheKey.Append($"{linkingCharacter}{parameter}");
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
