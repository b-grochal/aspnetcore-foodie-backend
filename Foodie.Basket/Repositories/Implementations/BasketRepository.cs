using Foodie.Basket.API.Exceptions;
using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task DeleteBasket(string customerId)
        {
            await distributedCache.RemoveAsync(customerId);
        }

        public async Task<CustomerBasket> GetBasket(string customerId)
        {
            var redisBasket = await distributedCache.GetStringAsync(customerId);

            if (string.IsNullOrEmpty(redisBasket))
                throw new CustomerBasketNotFound(customerId);

            return JsonSerializer.Deserialize<CustomerBasket>(redisBasket, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<CustomerBasket> UpdateBasket(string customerId, CustomerBasket basket)
        {
            await distributedCache.SetStringAsync(customerId, JsonSerializer.Serialize(basket));
            return await GetBasket(customerId);
        }
    }
}
