using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Domain.Results;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeEmailCommandHandler(IApplicationUsersRepository applicationUsersRepository, ICacheService cacheService, IBackgroundJobClient backgroundJobClient, IEmailsService emailsService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                return Result.Failure(ApplicationUserErrors.ApplicationUserNotFoundById(request.ApplicationUserId));

            if (applicationUser.Email == request.Email)
                return Result.Failure(ApplicationUserErrors.SameEmailAsOldOne());

            applicationUser.ChangeEmail(request.Email);

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
