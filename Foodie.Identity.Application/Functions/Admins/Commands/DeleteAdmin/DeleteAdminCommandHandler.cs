using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.DeleteAdmin
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, DeleteAdminCommandResponse>
    {
        private readonly IAdminsRepository _adminsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdminCommandHandler(IAdminsRepository adminsRepository, IUnitOfWork unitOfWork)
        {
            _adminsRepository = adminsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteAdminCommandResponse> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _adminsRepository.GetByIdAsync(request.Id);

            if (admin == null)
                throw new ApplicationUserNotFoundException(request.Id);

            await _adminsRepository.DeleteAsync(admin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteAdminCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
