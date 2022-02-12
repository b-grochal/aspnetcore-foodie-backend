using Foodie.Basket.Models;
using Foodie.Basket.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        public Task<bool> DeleteBasketAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> GetBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
