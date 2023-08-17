using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;

        public ChangeEmailCommandHandler(IApplicationUsersRepository applicationUsersRepository)
        {
            _applicationUsersRepository = applicationUsersRepository;
        }

        public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            if(applicationUser.Email == request.Email)
                throw new SameEmailAsOldOneException();

            applicationUser.Email = request.Email;

            await _applicationUsersRepository.UpdateAsync(applicationUser);
            return Unit.Value;
        }
    }
}
