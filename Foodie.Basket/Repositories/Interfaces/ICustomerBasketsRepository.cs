using Foodie.Basket.Model;
using System.Threading.Tasks;

namespace Foodie.Basket.Repositories.Interfaces
{
    public interface ICustomerBasketsRepository
    {
        Task<CustomerBasket> GetByCustomerId(int customerId);
        Task<CustomerBasket> UpdateBasket(int customerId, CustomerBasket basket);
        Task DeleteBasket(int customerId);
    }
}
