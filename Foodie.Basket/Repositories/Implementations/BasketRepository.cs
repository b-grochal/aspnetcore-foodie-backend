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
            var redisBasket = await distributedCache.GetAsync(userId);
            var serializedBasket = Encoding.UTF8.GetString(redisBasket);
            return JsonSerializer.Deserialize<CustomerBasket>(serializedBasket, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
