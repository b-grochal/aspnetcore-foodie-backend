using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries
{
    public interface IOrderQueries
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllAsync(string buyerEmail, string orderStatusName, int pageNumber, int pageSize);
    }
}
