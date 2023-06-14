using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInCommandResponse>
    {
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IRefreshTokensRepository refreshTokensRepository;
        private readonly IPasswordService passwordService;
        private readonly IJwtService jwtService;
        private readonly IRefreshTokenService refreshTokenService;

        public SignInCommandHandler(
            IApplicationUsersRepository applicationUserRolesRepository,
            IRefreshTokensRepository refreshTokensRepository,
            IPasswordService passwordService, 
            IJwtService jwtService, 
            IRefreshTokenService refreshTokenService)
        {
            this.applicationUsersRepository = applicationUserRolesRepository;
            this.refreshTokensRepository = refreshTokensRepository;
            this.passwordService = passwordService;
            this.jwtService = jwtService;
            this.refreshTokenService = refreshTokenService;
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

            var refreshTokenData = refreshTokenService.GenerateRefreshToken();

            await UpdateRefreshTokenForApplicationUser(applicationUser.Id, refreshTokenData);

            return new SignInCommandResponse
            {
                JwtToken = jwtService.GenerateToken(applicationUser),
                RefreshToken = refreshTokenData.RefreshToken
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

        private async Task UpdateRefreshTokenForApplicationUser(int applicationUserId, (string RefreshToken, DateTimeOffset ExpirationDate) refreshTokenData)
        {
            var refreshToken = await refreshTokensRepository.GetByApplicationUserIdAsync(applicationUserId);

            refreshToken.Token = refreshTokenData.RefreshToken;
            refreshToken.ExpirationTime = refreshTokenData.ExpirationDate;

            await refreshTokensRepository.UpdateAsync(refreshToken);
        }
    }
}
