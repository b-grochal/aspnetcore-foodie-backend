using AutoMapper;
using Foodie.Identity.Application.Features.Auth.Commands.SignUp;
using Foodie.Identity.Application.Features.MyAccount.Commands.UpdateAccountData;
using Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin;
using Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById;
using Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins;
using Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer;
using Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById;
using Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers;
using Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlerById;
using Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers;
using Foodie.Identity.Domain.Admins;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Customers;
using Foodie.Identity.Domain.OrderHandlers;

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
            ConfigureMyAccountMapping();
        }

        private void ConfigureAdminsMapping()
        {
            CreateMap<CreateAdminCommand, Admin>();
            CreateMap<Admin, CreateAdminCommandResponse>();
            CreateMap<UpdateAdminCommand, Admin>();
            CreateMap<Admin, UpdateAdminCommandResponse>();
            CreateMap<Admin, GetAdminByIdQueryResponse>();
            CreateMap<Admin, AdminDto>();
        }

        private void ConfigureCustomersMapping()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<Customer, CreateCustomerCommandResponse>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, UpdateCustomerCommandResponse>();
            CreateMap<Customer, GetCustomerByIdQueryResponse>();
            CreateMap<Customer, CustomerDto>();
        }

        private void ConfigureOrderHandlersMapping()
        {
            CreateMap<CreateOrderHandlerCommand, OrderHandler>();
            CreateMap<OrderHandler, CreateOrderHandlerCommandResponse>();
            CreateMap<UpdateOrderHandlerCommand, OrderHandler>();
            CreateMap<OrderHandler, UpdateOrderHandlerCommandResponse>();
            CreateMap<OrderHandler, GetOrderHandlerByIdQueryResponse>();
            CreateMap<OrderHandler, OrderHandlerDto>();
        }

        private void ConfigureAuthMapping()
        {
            CreateMap<SignUpCommand, Customer>();
            CreateMap<Customer, SignUpCommandResponse>();
        }

        private void ConfigureMyAccountMapping()
        {
            CreateMap<ApplicationUser, GetAccountDataQueryResponse>();
            CreateMap<UpdateAccountDataCommand, ApplicationUser>();
        }
    }
}
