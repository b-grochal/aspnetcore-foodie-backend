using Foodie.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasket(string userId);
        Task<CustomerBasket> UpdateBasket(CustomerBasket basket);
        Task DeleteBasket(string userId);
    }
}
