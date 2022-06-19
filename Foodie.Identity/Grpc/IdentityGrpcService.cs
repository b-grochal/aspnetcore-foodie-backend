using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Grpc.Core;
using IdentityGrpc;
using System;
using System.Threading.Tasks;

namespace Foodie.Identity.API.Grpc
{
    public class IdentityGrpcService : IdentityService.IdentityServiceBase
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public IdentityGrpcService(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public override async Task<GetCustomerResponse> GetCustomer(GetCustomerRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var customer = await customersRepository.GetByIdAsync(request.Id);
                    return new GetCustomerResponse
                    {
                        Customer = mapper.Map<Customer>(customer)
                    };
                }
                else
                {
                    return new GetCustomerResponse
                    {
                        Error = "ID is null or empty"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetCustomerResponse
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}
