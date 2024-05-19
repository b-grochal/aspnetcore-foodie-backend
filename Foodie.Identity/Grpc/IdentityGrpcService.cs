using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Grpc.Core;
using IdentityGrpc;
using System;
using System.Threading.Tasks;

namespace Foodie.Identity.API.Grpc
{
    public class IdentityGrpcService : IdentityService.IdentityServiceBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public IdentityGrpcService(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public override async Task<GetCustomerResponse> GetCustomer(GetCustomerRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var customer = await _customersRepository.GetByIdAsync(request.Id);
                    return new GetCustomerResponse
                    {
                        Customer = _mapper.Map<Customer>(customer)
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
