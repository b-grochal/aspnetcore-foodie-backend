﻿using AutoMapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers;
using Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById;
using Foodie.Orders.Application.Features.Contractors.Queries.GetContractors;
using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById;
using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders;
using Foodie.Orders.Application.Features.Orders.Queries.GetOrderById;
using Foodie.Orders.Application.Features.Orders.Queries.GetOrders;

namespace Foodie.Orders.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ConfigureOrdersMapping();
            ConfigureBuyersMapping();
            ConfigureContractorsMapping();
            ConfigureMyOrdersMapping();
        }

        private void ConfigureOrdersMapping()
        {
            CreateMap<OrderDetailsQueryDto, GetOrderByIdQueryResponse>();
            CreateMap<OrderItemQueryDto, OrderItemDto>();
            CreateMap<OrderQueryDto, OrderDto>();
        }

        private void ConfigureBuyersMapping()
        {
            CreateMap<BuyerDetailsQueryDto, GetBuyerByIdQueryResponse>();
            CreateMap<BuyerQueryDto, BuyerDto>();
        }

        private void ConfigureContractorsMapping()
        {
            CreateMap<ContractorDetailsQueryDto, GetContractorByIdQueryResponse>();
            CreateMap<ContractorQueryDto, ContractorDto>();
        }

        private void ConfigureMyOrdersMapping()
        {
            CreateMap<OrderQueryDto, MyOrderDto>();
            CreateMap<OrderDetailsQueryDto, GetMyOrderByIdQueryResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<OrderItemQueryDto, MyOrderItemDto>();
        }
    }
}
