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

namespace Foodie.Identity.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ConfigureAdminsMapping();
            ConfigureCustomersMapping();
            ConfigureOrderHandlersMapping();
            ConfigureAuthMapping();
        }

        private void ConfigureAdminsMapping()
        {
            CreateMap<CreateAdminCommand, Admin>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<Admin, CreateAdminCommandResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));
            CreateMap<UpdateAdminCommand, Admin>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AdminId));
            CreateMap<Admin, UpdateAdminCommandResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Admin, GetAdminByIdQueryResponse>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Admin, AdminDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.Id));
        }

        private void ConfigureCustomersMapping()
        {
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
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
        }

        private void ConfigureOrderHandlersMapping()
        {
            CreateMap<CreateOrderHandlerCommand, OrderHandler>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
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
        }

        private void ConfigureAuthMapping()
        {
            CreateMap<SignUpCommand, Customer>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<Customer, SignUpCommandResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
