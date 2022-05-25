using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInCommandResponse>
    {
        private readonly IApplicationUserRolesRepository applicationUserRolesRepository;
        private readonly IAuthService authService;
        private readonly IJwtService jwtService;

        public SignInCommandHandler(IApplicationUserRolesRepository applicationUserRolesRepository, IAuthService authService, IJwtService jwtService)
        {
            this.applicationUserRolesRepository = applicationUserRolesRepository;
            this.authService = authService;
            this.jwtService = jwtService;
        }

        public async Task<SignInCommandResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await authService.AuthenticateUser(request.Email, request.Password);
            var role = await applicationUserRolesRepository.GetApplicationUserRole(applicationUser.Id);

            return new SignInCommandResponse
            {
                Token = jwtService.GenerateToken(applicationUser.Id, role)
            };
        }
    }
}
