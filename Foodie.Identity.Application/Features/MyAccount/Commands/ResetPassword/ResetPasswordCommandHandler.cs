using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
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

        public ResetPasswordCommandHandler(IApplicationUsersRepository applicationUsersRepository, ICacheService cacheService, IBackgroundJobClient backgroundJobClient, IEmailsService emailsService)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
        }

        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByEmailAsync(request.Email);

            if (applicationUser is null)
                return Result.Failure(ApplicationUserErrors.ApplicationUserNotFoundByEmail(request.Email));

            var setPasswordToken = Guid.NewGuid().ToString();
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
