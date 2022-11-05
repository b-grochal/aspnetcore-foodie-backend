using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries
{
    public interface IOrderQueries
    {
        Task<OrderDetailsQueryDto> GetByIdAsync(int id);
        Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, string buyerEmail, string orderStatusName, string contractorName);
    }
}
