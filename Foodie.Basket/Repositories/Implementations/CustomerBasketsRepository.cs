using Foodie.Basket.Model;
using Foodie.Basket.Repositories.Interfaces;
using Foodie.Shared.Cache;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Implementations
{
    public class CustomerBasketsRepository : ICustomerBasketsRepository
    {
        private readonly ICacheService cacheService;

        public CustomerBasketsRepository(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task DeleteBasket(string customerId)
        {
            await cacheService.RemoveAsync(CachePrefixes.Basket, nameof(CustomerBasketsRepository), new string[] { nameof(customerId), customerId });
        }

        public async Task<CustomerBasket> GetByCustomerId(string customerId)
        {
            return await cacheService.GetAsync<CustomerBasket>(CachePrefixes.Basket, nameof(CustomerBasketsRepository), new string[] { nameof(customerId), customerId });
        }

        public async Task<CustomerBasket> UpdateBasket(string customerId, CustomerBasket basket)
        {
            await cacheService.SetAsync<CustomerBasket>(basket, CachePrefixes.Basket, nameof(CustomerBasketsRepository), new string[] { nameof(customerId), customerId });
            return await GetByCustomerId(customerId);
        }
    }
}
