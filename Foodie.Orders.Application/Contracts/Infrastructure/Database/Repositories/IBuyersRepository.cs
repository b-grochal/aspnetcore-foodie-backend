using Foodie.Orders.Domain.Buyers;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface IBuyersRepository : IRepository<Buyer>
    {
        Buyer Create(Buyer buyer);
        Buyer Update(Buyer buyer);
        Task<Buyer> GetByIdAsync(int id);
        Task<Buyer> GetByCustomerIdAsync(string userId);
    }
}
