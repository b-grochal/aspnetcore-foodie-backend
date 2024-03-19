using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.MyAccount.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ActivateAccount
{
    public class ActivateAccountCommandHandler : IRequestHandler<ActivateAccountCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateAccountCommandHandler(
            IApplicationUsersRepository applicationUsersRepository, 
            ICacheService cacheService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
        {
            var applicationUserEmail = await _cacheService.GetAsync<string>(CachePrefixes.AccountActivationTokens, string.Empty, CacheParameters.AccountActivationToken, request.AccountActivationToken);

            if (applicationUserEmail is null)
                return Result.Failure(TokenErrors.InvalidAccountActivationToken());

            var applicationUser = await _applicationUsersRepository.GetByEmailAsync(applicationUserEmail);

            if (applicationUser is null)
                return Result.Failure(Common.ApplicationUserErrors.ApplicationUserNotFoundByEmail(applicationUserEmail));

            applicationUser.Activate();

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _cacheService.RemoveAsync(CachePrefixes.AccountActivationTokens, string.Empty, CacheParameters.AccountActivationToken, request.AccountActivationToken);

            return Result.Success();
        }
    }
}
