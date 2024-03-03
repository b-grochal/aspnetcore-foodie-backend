using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using Foodie.Identity.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ActivateAccount
{
    public class ActivateAccountCommandHandler : IRequestHandler<ActivateAccountCommand>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateAccountCommandHandler(IApplicationUsersRepository applicationUsersRepository, ICacheService cacheService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _cacheService.GetAsync<ApplicationUser>(CachePrefixes.AccountActivationTokens, string.Empty, CacheParameters.AccountActivationToken, request.AccountActivationToken);

            if (applicationUser is null)
                throw new InvalidAccountActivationTokenException();

            applicationUser = await _applicationUsersRepository.GetByIdAsync(applicationUser.Id);

            if (applicationUser is null)
                throw new ApplicationUserNotFoundException();

            applicationUser.IsActive = true;

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _cacheService.RemoveAsync(CachePrefixes.AccountActivationTokens, string.Empty, CacheParameters.AccountActivationToken, request.AccountActivationToken);

            return Unit.Value;
        }
    }
}
