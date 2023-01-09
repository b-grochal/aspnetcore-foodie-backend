using Foodie.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<Models.CustomerBasket> GetBasket(string userId);
        Task<Models.CustomerBasket> UpdateBasket(string customerId, CustomerBasket basket);
        Task DeleteBasket(string userId);
    }
}
