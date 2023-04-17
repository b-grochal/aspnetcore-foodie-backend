using Foodie.Basket.API.Exceptions;
using Foodie.Basket.Model;
using Foodie.Basket.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Implementations
{
    public class CustomerBasketsRepository : ICustomerBasketsRepository
    {
        private readonly IDistributedCache distributedCache;

        public CustomerBasketsRepository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task DeleteBasket(string customerId)
        {
            await distributedCache.RemoveAsync(customerId);
        }

        public async Task<CustomerBasket> GetByCustomerId(string customerId)
        {
            var redisBasket = await distributedCache.GetStringAsync(customerId);

            if (string.IsNullOrEmpty(redisBasket))
                return null;

            return JsonSerializer.Deserialize<CustomerBasket>(redisBasket, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<CustomerBasket> UpdateBasket(string customerId, CustomerBasket basket)
        {
            await distributedCache.SetStringAsync(customerId, JsonSerializer.Serialize(basket));
            return await GetByCustomerId(customerId);
        }
    }
}
