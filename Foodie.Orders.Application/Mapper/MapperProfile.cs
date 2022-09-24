using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Orders
            CreateMap<OrderDetailsQueryDto, GetOrderByIdQueryResponse>();
            CreateMap<OrderItemQueryDto, OrderItemDto>();
            CreateMap<OrderQueryDto, OrderDto>();
        }
    }
}
