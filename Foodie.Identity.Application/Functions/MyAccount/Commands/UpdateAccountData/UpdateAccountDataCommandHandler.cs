using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateAccountDataCommandHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAccountDataCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser == null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            applicationUser = _mapper.Map(request, applicationUser);
            await _applicationUsersRepository.UpdateAsync(applicationUser);
            return Unit.Value;
        }
    }
}
