using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;
        private readonly IAccountTokensService _accountTokensService;

        public ResetPasswordCommandHandler(
            IApplicationUsersRepository applicationUsersRepository,
            ICacheService cacheService,
            IBackgroundJobClient backgroundJobClient,
            IEmailsService emailsService, 
            IAccountTokensService accountTokensService)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
            _accountTokensService = accountTokensService;
        }

        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByEmailAsync(request.Email);

            if (applicationUser is null)
                return Result.Failure(Common.ApplicationUserErrors.ApplicationUserNotFoundByEmail(request.Email));

            var setPasswordToken = _accountTokensService.GenerateSetPasswordToken();

            await _cacheService.SetAsync(applicationUser.Email,
                                                          CachePrefixes.SetPasswordToken,
                                                          string.Empty,
                                                          CacheParameters.SetPasswordToken,
                                                          setPasswordToken);

            _backgroundJobClient.Enqueue(() => _emailsService.SendAccountActivationEmail(applicationUser.Email, setPasswordToken));

            return Result.Success();
        }
    }
}
