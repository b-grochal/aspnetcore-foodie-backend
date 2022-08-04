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
        Buyer Create(Buyer buyer);
        void Update(Buyer buyer);
        Task<Buyer> GetByIdAsync(int id);
    }
}
