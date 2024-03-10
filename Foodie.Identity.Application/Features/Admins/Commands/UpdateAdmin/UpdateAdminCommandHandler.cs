using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdateAdminCommandResponse>
    {
        private readonly IAdminsRepository _adminsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAdminCommandHandler(IAdminsRepository adminsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _adminsRepository = adminsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateAdminCommandResponse> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _adminsRepository.GetByIdAsync(request.Id);

            if (admin == null)
                throw new ApplicationUserNotFoundException(request.Id);

            var updatedAdmin = _mapper.Map(request, admin);
            await _adminsRepository.UpdateAsync(updatedAdmin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateAdminCommandResponse>(updatedAdmin);
        }
    }
}
