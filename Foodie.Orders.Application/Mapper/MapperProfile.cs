﻿using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyerById;
using Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers;
using Foodie.Orders.Application.Functions.Contractors.Queries.GetContractorById;
using Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors;
using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrderById;
using Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders;
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

            // Buyers
            CreateMap<BuyerDetailsQueryDto, GetBuyerByIdQueryResponse>();
            CreateMap<BuyerQueryDto, BuyerDto>();

            // Contractors
            CreateMap<ContractorDetailsQueryDto, GetContractorByIdQueryResponse>();
            CreateMap<ContractorQueryDto, ContractorDto>();

            // MyOrders
            CreateMap<OrderQueryDto, CustomersOrderDto>();
            CreateMap<OrderDetailsQueryDto, GetCustomersOrderByIdQueryResponse>()
                .ForMember(dest => dest.CustomersOrderItems, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<OrderItemQueryDto, CustomersOrderItemDto>();
        }
    }
}
