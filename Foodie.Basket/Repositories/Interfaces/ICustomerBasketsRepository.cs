using Foodie.Basket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Interfaces
{
    public interface ICustomerBasketsRepository
    {
        Task<CustomerBasket> GetByCustomerId(string customerId);
        Task<CustomerBasket> UpdateBasket(string customerId, CustomerBasket basket);
        Task DeleteBasket(string userId);
    }
}
