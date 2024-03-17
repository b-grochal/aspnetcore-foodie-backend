using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommandHandler : IRequestHandler<RefreshJwtTokenCommand, Result<RefreshJwtTokenCommandResponse>>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;

        public RefreshJwtTokenCommandHandler(
            IApplicationUsersRepository applicationUsersRepository,
            IJwtService jwtService,
            IRefreshTokenService refreshTokenService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<RefreshJwtTokenCommandResponse>> Handle(RefreshJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var applicationUserId = _jwtService.GetApplicationUserIdFromExpiredToken(request.JwtToken);

            var applicationUser = await _applicationUsersRepository.GetByIdAsync(applicationUserId);

            if (applicationUser.RefreshToken is null)
                return Result.Failure<RefreshJwtTokenCommandResponse>(ApplicationUserErrors.RefreshTokenNotFound(applicationUserId));

            if (applicationUser.RefreshToken.Token != request.RefreshToken || applicationUser.RefreshToken.ExpirationTime <= DateTimeOffset.Now)
                return Result.Failure<RefreshJwtTokenCommandResponse>(ApplicationUserErrors.InvalidRefreshToken());

            var newJwtToken = _jwtService.GenerateToken(applicationUser);
            var newRefreshTokenData = _refreshTokenService.GenerateRefreshToken();

            applicationUser.UpdateRefreshToken(newRefreshTokenData.RefreshToken, newRefreshTokenData.ExpirationDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new RefreshJwtTokenCommandResponse
            {
                JwtToken = newJwtToken,
                RefreshToken = newRefreshTokenData.RefreshToken,
            };
        }
    }
}
