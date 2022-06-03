using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Grpc.Core;
using IdentityGrpc;

namespace Foodie.Identity.Grpc
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

        public override async Task<GetApplicationUserResponse> GetApplicationUser(GetApplicationUserRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var applicationUser = await customersRepository.GetByIdAsync(request.Id);
                    return new GetApplicationUserResponse
                    {
                        ApplicationUser = mapper.Map<ApplicationUser>(applicationUser)
                    };
                }
                else
                {
                    return new GetApplicationUserResponse
                    {
                        Error = "ID is null or empty"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetApplicationUserResponse
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}
