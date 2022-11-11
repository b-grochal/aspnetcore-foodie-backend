using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors
{
    public interface IContractorsQueries
    {
        Task<ContractorDetailsQueryDto> GetByIdAsync(int id);
        Task<PagedList<ContractorQueryDto>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? locationId, int? cityId);
    }
}
