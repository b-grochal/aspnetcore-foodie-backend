using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IPasswordService _passwordService;

        public ChangePasswordCommandHandler(IApplicationUsersRepository applicationUsersRepository, IPasswordService passwordService)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _passwordService = passwordService;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if(applicationUser is null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            applicationUser.PasswordHash = _passwordService.HashPassword(request.Password);

            await _applicationUsersRepository.UpdateAsync(applicationUser);
            return Unit.Value;
        }
    }
}
