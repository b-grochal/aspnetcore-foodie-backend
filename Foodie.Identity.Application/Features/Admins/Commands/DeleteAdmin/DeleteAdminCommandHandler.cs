using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, Result<DeleteAdminCommandResponse>>
    {
        private readonly IAdminsRepository _adminsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdminCommandHandler(IAdminsRepository adminsRepository, IUnitOfWork unitOfWork)
        {
            _adminsRepository = adminsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteAdminCommandResponse>> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _adminsRepository.GetByIdAsync(request.Id);

            if (admin is null)
                return Result.Failure<DeleteAdminCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            await _adminsRepository.DeleteAsync(admin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteAdminCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
