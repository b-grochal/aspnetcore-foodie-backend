using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RevokeRefreshTokenCommandHandler(IApplicationUsersRepository applicationUsersRepository, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                return Result.Failure(ApplicationUserErrors.ApplicationUserNotFoundById(request.ApplicationUserId));

            applicationUser.RevokeRefreshToken();

            await _unitOfWork.CommitChangesAsync(string.Empty, cancellationToken);

            return Result.Success();
        }
    }
}
