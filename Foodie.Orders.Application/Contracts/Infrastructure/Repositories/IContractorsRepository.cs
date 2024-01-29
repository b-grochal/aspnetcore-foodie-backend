using Foodie.Orders.Domain.Contractors;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Repositories
{
    public interface IContractorsRepository : IRepository<Contractor>
    {
        Contractor Create(Contractor contractor);
        Contractor Update(Contractor contractor);
        Task<Contractor> GetByIdAsync(int id);
        Task<Contractor> GetByParametersAsync(int restaurantId, int locationId, int cityId);
    }
}
