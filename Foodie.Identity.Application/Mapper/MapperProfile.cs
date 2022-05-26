using AutoMapper;
using Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin;
using Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins;
using Foodie.Identity.Application.Functions.Auth.Commands.SignUp;
using Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers;
using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Admins
            CreateMap<CreateAdminCommand, OrderHandler>();

            CreateMap<OrderHandler, CreateAdminCommandResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateAdminCommand, OrderHandler>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AdminId));

            CreateMap<OrderHandler, UpdateAdminCommandResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));

            CreateMap<OrderHandler, GetAdminByIdQueryResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));

            CreateMap<OrderHandler, AdminDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));

            // Customers
            CreateMap<CreateCustomerCommand, Customer>();

            CreateMap<Customer, CreateCustomerCommandResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));

            CreateMap<Customer, UpdateCustomerCommandResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Customer, GetCustomerByIdQueryResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));

            // Order handlers
            CreateMap<CreateOrderHandlerCommand, OrderHandler>();

            CreateMap<OrderHandler, CreateOrderHandlerCommandResponse>()
                .ForMember(dest => dest.OrderHandlerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateOrderHandlerCommand, OrderHandler>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderHandlerId));

            CreateMap<OrderHandler, UpdateOrderHandlerCommandResponse>()
                .ForMember(dest => dest.OrderHandlerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<OrderHandler, GetOrderHandlerByIdQueryResponse>()
                .ForMember(dest => dest.OrderHandlerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<OrderHandler, OrderHandlerDto>()
                .ForMember(dest => dest.OrderHandlerId, opt => opt.MapFrom(src => src.Id));

            // Auth
            CreateMap<SignUpCommand, Customer>();

            CreateMap<Customer, SignUpCommandResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
