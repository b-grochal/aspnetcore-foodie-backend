using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Domain.Common.ApplicationUser.DomainEvents;
using Foodie.Templates.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.ApplicationUsers.DomainEventsHandlers
{
    public class SendEmailWithAccountActivationTokenToApplicationUserWhenApplicationUserCreatedDomainEventHandler : INotificationHandler<ApplicationUserCreatedDomainEvent>
    {
        private readonly IAccountTokensService _accountTokensService;
        private readonly ICacheService _cacheService;
        private readonly IEmailsService _emailsService;

        public SendEmailWithAccountActivationTokenToApplicationUserWhenApplicationUserCreatedDomainEventHandler(
            IAccountTokensService accountTokensService, 
            ICacheService cacheService, 
            IEmailsService emailsService)
        {
            _accountTokensService = accountTokensService;
            _cacheService = cacheService;
            _emailsService = emailsService;
        }

        public async Task Handle(ApplicationUserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var accountActivationToken = _accountTokensService.GenerateAccountActivationToken();

            await _cacheService.SetAsync<string>(notification.ApplicationUserEmail,
                                                          CachePrefixes.AccountActivationTokens,
                                                          string.Empty,
                                                          CacheParameters.AccountActivationToken,
                                                          accountActivationToken);

            await _emailsService.SendAccountActivationEmail(notification.ApplicationUserEmail, accountActivationToken);
        }
    }
}
