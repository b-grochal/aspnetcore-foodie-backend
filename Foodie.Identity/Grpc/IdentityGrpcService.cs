using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Foodie.Identity.Repositories.Interfaces;
using Grpc.Core;
using IdentityGrpc;

namespace Foodie.Identity.Grpc
{
    public class IdentityGrpcService : IdentityService.IdentityServiceBase
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IMapper mapper;

        public IdentityGrpcService(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            this.applicationUsersRepository = applicationUsersRepository;
            this.mapper = mapper;
        }

        public override async Task<GetApplicationUserResponse> GetApplicationUser(GetApplicationUserRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var applicationUser = await applicationUsersRepository.GetApplicationUser(request.Id);
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
