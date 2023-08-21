using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Cache;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;

        public ChangeEmailCommandHandler(IApplicationUsersRepository applicationUsersRepository, ICacheService cacheService, IBackgroundJobClient backgroundJobClient, IEmailsService emailsService)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
        }

        public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            if(applicationUser.Email == request.Email)
                throw new SameEmailAsOldOneException();

            applicationUser.Email = request.Email;
            applicationUser.IsActive = false;

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            var accountActivationToken = Guid.NewGuid().ToString();

            await _cacheService.SetAsync<ApplicationUser>(applicationUser,
                                                          CachePrefixes.AccountActivationTokens,
                                                          string.Empty,
                                                          CacheParameters.AccountActivationToken,
                                                          accountActivationToken);

            _backgroundJobClient.Enqueue(() => _emailsService.SendAccountActivationEmail(applicationUser.Email, accountActivationToken));

            return Unit.Value;
        }
    }
}
