using Foodie.Orders.Domain.AggregatesModel.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Repositories
{
    public interface IBuyersRepository : IRepository<Buyer>
    {
        Task<Buyer> CreateAsync(Buyer buyer);
        Task UpdateAsync(Buyer buyer);
        Task<Buyer> GetByIdAsync(int id);
    }
}
