using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeEmailCommandHandler(IApplicationUsersRepository applicationUsersRepository,
            IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                return Result.Failure(ApplicationUserErrors.ApplicationUserNotFoundById(request.ApplicationUserId));

            var result = applicationUser.ChangeEmail(request.Email);

            if (result.IsFailure)
                return result;

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.CommitChangesAsync(GetType().Name, cancellationToken);

            return Result.Success();
        }
    }
}
