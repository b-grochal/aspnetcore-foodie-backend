using Foodie.Common.Application.Contracts.Infrastructure.Database;
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
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordCommandHandler(IApplicationUsersRepository applicationUsersRepository, IPasswordService passwordService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _passwordService = passwordService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if(applicationUser is null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            applicationUser.PasswordHash = _passwordService.HashPassword(request.Password);

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
