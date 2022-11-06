using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Queries
{
    public class ContractorsQueries : IContractorsQueries
    {
        public Task<PagedList<ContractorQueryDto>> GetAllAsync(int pageNumber, int pageSize, int restaurantNumber, int locationId, int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<ContractorDetailsQueryDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
