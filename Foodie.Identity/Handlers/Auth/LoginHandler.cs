using Foodie.Identity.Commands.Auth;
using Foodie.Identity.Repositories.Interfaces;
using Foodie.Identity.Responses.Auth;
using Foodie.Identity.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Handlers.Auth
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IApplicationUserRolesRepository applicationUserRolesRepository;
        private readonly IAuthService authService;
        private readonly IJwtService jwtService;

        public LoginHandler(IApplicationUserRolesRepository applicationUserRolesRepository, IAuthService authService, IJwtService jwtService)
        {
            this.applicationUserRolesRepository = applicationUserRolesRepository;
            this.authService = authService;
            this.jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authenticatedApplicationUser = await authService.AuthenticateUser(request.Email, request.Password);
            var role = await applicationUserRolesRepository.GetApplicationUserRole(authenticatedApplicationUser.Id);

            return new LoginResponse
            {
                Token = jwtService.GenerateToken(authenticatedApplicationUser.Id, role)
            };
        }
    }
}
