using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand>
    {
        private readonly IRefreshTokensRepository refreshTokensRepository;

        public RevokeRefreshTokenCommandHandler(IRefreshTokensRepository refreshTokensRepository)
        {
            this.refreshTokensRepository = refreshTokensRepository;
        }

        public async Task<Unit> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await refreshTokensRepository.GetByApplicationUserIdAsync(request.ApplicationUserId);

            if (refreshToken is null)
                throw new RefreshTokenForApplicationUserNotFoundException(request.ApplicationUserId);

            refreshToken.Token = null;
            refreshToken.ExpirationTime = null;

            await refreshTokensRepository.UpdateAsync(refreshToken);

            return Unit.Value;
        }
    }
}
