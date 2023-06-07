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

        public async Task DeleteBasket(int customerId)
        {
            await cacheService.RemoveAsync(CachePrefixes.Basket, nameof(CustomerBasketsRepository), new string[] { nameof(customerId), customerId.ToString() });
        }

        public async Task<CustomerBasket> GetByCustomerId(int customerId)
        {
            return await cacheService.GetAsync<CustomerBasket>(CachePrefixes.Basket, nameof(CustomerBasketsRepository), new string[] { nameof(customerId), customerId.ToString() });
        }

        public async Task<CustomerBasket> UpdateBasket(int customerId, CustomerBasket basket)
        {
            await cacheService.SetAsync<CustomerBasket>(basket, CachePrefixes.Basket, nameof(CustomerBasketsRepository), new string[] { nameof(customerId), customerId.ToString() });
            return await GetByCustomerId(customerId);
        }
    }
}
