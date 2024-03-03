using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.UpdateAccountData
{
    public class UpdateAccountDataCommandHandler : IRequestHandler<UpdateAccountDataCommand>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccountDataCommandHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAccountDataCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser == null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            applicationUser = _mapper.Map(request, applicationUser);
            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
