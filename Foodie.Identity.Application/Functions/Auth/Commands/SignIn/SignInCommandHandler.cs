using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInCommandResponse>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IPasswordService passwordService;
        private readonly IJwtService jwtService;

        public SignInCommandHandler(IApplicationUsersRepository applicationUserRolesRepository, IPasswordService passwordService, IJwtService jwtService)
        {
            this.applicationUsersRepository = applicationUserRolesRepository;
            this.passwordService = passwordService;
            this.jwtService = jwtService;
        }

        public async Task<SignInCommandResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await applicationUsersRepository.GetByEmailAsync(request.Email);

            if (applicationUser == null)
                throw new ApplicationUserNotFoundException(request.Email);

            if (applicationUser.IsLocked)
                throw new ApplicationUserLockedException(request.Email);

            if (!passwordService.VerifyPassword(request.Password, applicationUser.PasswordHash))
                await HandleInvalidAuthentication(applicationUser);

            return new SignInCommandResponse
            {
                Token = jwtService.GenerateToken(applicationUser)
            };
        }

        private async Task HandleInvalidAuthentication(ApplicationUser applicationUser)
        {
            applicationUser.AccessFailedCount++;

            if (applicationUser.AccessFailedCount == 5)
                applicationUser.IsLocked = true;

            await applicationUsersRepository.UpdateAsync(applicationUser);

            throw new ApplicationUserNotAuthenticatedException(applicationUser.Email);
        }
    }
}
