using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.UpdateAdmin
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, Result<UpdateAdminCommandResponse>>
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

        public async Task<Result<UpdateAdminCommandResponse>> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _adminsRepository.GetByIdAsync(request.Id);

            if (admin is null)
                return Result.Failure<UpdateAdminCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id)); ;

            admin.Update(request.FirstName, request.LastName, request.PhoneNumber, request.Email);

            await _adminsRepository.UpdateAsync(admin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateAdminCommandResponse>(admin);
        }
    }
}
