using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Domain.Results;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.SetPassword
{
    public class SetPasswordCommandHandler : IRequestHandler<SetPasswordCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IPasswordService _passwordService;
        private readonly IUnitOfWork _unitOfWork;

        public SetPasswordCommandHandler(IApplicationUsersRepository applicationUsersRepository, ICacheService cacheService, IPasswordService passwordService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _passwordService = passwordService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            var applicationUserEmail = await _cacheService.GetAsync<string>(CachePrefixes.SetPasswordToken,
                                                          string.Empty,
                                                          CacheParameters.SetPasswordToken,
                                                          request.SetPasswordToken);

            if (applicationUserEmail is null)
                return Result.Failure(ApplicationUserErrors.InvalidSetPasswordToken());

            var applicationUser = await _applicationUsersRepository.GetByEmailAsync(applicationUserEmail);

            if (applicationUserEmail is null)
                return Result.Failure(ApplicationUserErrors.ApplicationUserNotFoundByEmail(applicationUserEmail));

            applicationUser.ChangePassword(_passwordService.HashPassword(request.Password));

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _cacheService.RemoveAsync(CachePrefixes.SetPasswordToken, string.Empty, CacheParameters.SetPasswordToken,
                                                          request.SetPasswordToken);

            return Result.Success();
        }
    }
}
