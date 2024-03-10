using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand>
    {
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RevokeRefreshTokenCommandHandler(IRefreshTokensRepository refreshTokensRepository, IUnitOfWork unitOfWork)
        {
            _refreshTokensRepository = refreshTokensRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _refreshTokensRepository.GetByApplicationUserIdAsync(request.ApplicationUserId);

            if (refreshToken is null)
                throw new RefreshTokenForApplicationUserNotFoundException(request.ApplicationUserId);

            refreshToken.Token = null;
            refreshToken.ExpirationTime = null;

            await _refreshTokensRepository.UpdateAsync(refreshToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
