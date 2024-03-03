using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommandHandler : IRequestHandler<RefreshJwtTokenCommand, RefreshJwtTokenCommandResponse>
    {
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;

        public RefreshJwtTokenCommandHandler(IRefreshTokensRepository refreshTokensRepository,
            IApplicationUsersRepository applicationUsersRepository,
            IJwtService jwtService,
            IRefreshTokenService refreshTokenService, IUnitOfWork unitOfWork)
        {
            _refreshTokensRepository = refreshTokensRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<RefreshJwtTokenCommandResponse> Handle(RefreshJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var applicationUserId = _jwtService.GetApplicationUserIdFromExpiredToken(request.JwtToken);
            var refreshToken = await _refreshTokensRepository.GetByApplicationUserIdAsync(applicationUserId);

            if (refreshToken == null)
                throw new RefreshTokenForApplicationUserNotFoundException(applicationUserId);

            if (refreshToken.Token != request.RefreshToken || refreshToken.ExpirationTime <= DateTimeOffset.Now)
                throw new InvalidRefreshTokenException();

            var applicationUser = await _applicationUsersRepository.GetByIdAsync(applicationUserId);
            var newJwtToken = _jwtService.GenerateToken(applicationUser);
            var newRefreshTokenData = _refreshTokenService.GenerateRefreshToken();

            refreshToken.Token = newRefreshTokenData.RefreshToken;
            refreshToken.ExpirationTime = newRefreshTokenData.ExpirationDate;

            await _refreshTokensRepository.UpdateAsync(refreshToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new RefreshJwtTokenCommandResponse
            {
                JwtToken = newJwtToken,
                RefreshToken = newRefreshTokenData.RefreshToken,
            };
        }
    }
}
