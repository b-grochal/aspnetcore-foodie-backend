using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Foodie.Common.Application.Contracts.Infrastructure.Database;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInCommandResponse>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUnitOfWork _unitOfWork;

        public SignInCommandHandler(
            IApplicationUsersRepository applicationUserRolesRepository,
            IRefreshTokensRepository refreshTokensRepository,
            IPasswordService passwordService,
            IJwtService jwtService,
            IRefreshTokenService refreshTokenService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUserRolesRepository;
            _refreshTokensRepository = refreshTokensRepository;
            _passwordService = passwordService;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInCommandResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByEmailAsync(request.Email);

            if (applicationUser == null)
                throw new ApplicationUserNotFoundException(request.Email);

            if (applicationUser.IsLocked)
                throw new ApplicationUserLockedException(request.Email);

            if (!applicationUser.IsActive)
                throw new ApplicationUserNotActivatedException(request.Email);

            if (!_passwordService.VerifyPassword(request.Password, applicationUser.PasswordHash))
                await HandleInvalidAuthentication(applicationUser);

            var refreshTokenData = _refreshTokenService.GenerateRefreshToken();

            await UpdateRefreshTokenForApplicationUser(applicationUser.Id, refreshTokenData);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SignInCommandResponse
            {
                JwtToken = _jwtService.GenerateToken(applicationUser),
                RefreshToken = refreshTokenData.RefreshToken
            };
        }

        private async Task HandleInvalidAuthentication(ApplicationUser applicationUser)
        {
            applicationUser.AccessFailedCount++;

            if (applicationUser.AccessFailedCount == 5)
                applicationUser.IsLocked = true;

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            throw new ApplicationUserNotAuthenticatedException(applicationUser.Email);
        }

        private async Task UpdateRefreshTokenForApplicationUser(int applicationUserId, (string RefreshToken, DateTimeOffset ExpirationDate) refreshTokenData)
        {
            var refreshToken = await _refreshTokensRepository.GetByApplicationUserIdAsync(applicationUserId);

            refreshToken.Token = refreshTokenData.RefreshToken;
            refreshToken.ExpirationTime = refreshTokenData.ExpirationDate;

            await _refreshTokensRepository.UpdateAsync(refreshToken);
        }
    }
}
