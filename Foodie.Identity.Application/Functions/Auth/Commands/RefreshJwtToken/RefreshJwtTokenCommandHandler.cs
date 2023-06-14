using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommandHandler : IRequestHandler<RefreshJwtTokenCommand, RefreshJwtTokenCommandResponse>
    {
        private readonly IRefreshTokensRepository refreshTokensRepository;
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IJwtService jwtService;
        private readonly IRefreshTokenService refreshTokenService;

        public RefreshJwtTokenCommandHandler(IRefreshTokensRepository refreshTokensRepository, 
            IApplicationUsersRepository applicationUsersRepository, 
            IJwtService jwtService, 
            IRefreshTokenService refreshTokenService)
        {
            this.refreshTokensRepository = refreshTokensRepository;
            this.applicationUsersRepository = applicationUsersRepository;
            this.jwtService = jwtService;
            this.refreshTokenService = refreshTokenService;
        }

        public async Task<RefreshJwtTokenCommandResponse> Handle(RefreshJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var applicationUserId = jwtService.GetApplicationUserIdFromExpiredToken(request.JwtToken);
            var refreshToken = await refreshTokensRepository.GetByApplicationUserIdAsync(applicationUserId);

            if (refreshToken == null)
                throw new RefreshTokenForApplicationUserNotFoundException(applicationUserId);

            if (refreshToken.Token != request.RefreshToken || refreshToken.ExpirationTime <= DateTimeOffset.Now)
                throw new InvalidRefreshTokenException();

            var applicationUser = await applicationUsersRepository.GetByIdAsync(applicationUserId);
            var newJwtToken = jwtService.GenerateToken(applicationUser);
            var newRefreshTokenData = refreshTokenService.GenerateRefreshToken();

            refreshToken.Token = newRefreshTokenData.RefreshToken;
            refreshToken.ExpirationTime = newRefreshTokenData.ExpirationDate;

            await refreshTokensRepository.UpdateAsync(refreshToken);

            return new RefreshJwtTokenCommandResponse
            {
                JwtToken = newJwtToken,
                RefreshToken = newRefreshTokenData.RefreshToken,
            };
        }
    }
}
