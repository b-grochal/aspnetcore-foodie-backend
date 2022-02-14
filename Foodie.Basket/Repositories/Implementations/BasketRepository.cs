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

        public async Task DeleteBasket(string userId)
        {
            await distributedCache.RemoveAsync(userId);
        }

        public async Task<CustomerBasket> GetBasket(string userId)
        {
            var redisBasket = await distributedCache.GetStringAsync(userId);
            return JsonSerializer.Deserialize<CustomerBasket>(redisBasket, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            await distributedCache.SetStringAsync(basket.UserId, JsonSerializer.Serialize(basket));
            return await GetBasket(basket.UserId);
        }
    }
}
