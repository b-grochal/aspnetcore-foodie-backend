using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Admins;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Result<CreateAdminCommandResponse>>
    {
        private readonly IAdminsRepository _adminsRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public CreateAdminCommandHandler(IAdminsRepository adminsRepository,
            IApplicationUsersRepository applicationUsersRepository,
            IPasswordService passwordService, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _adminsRepository = adminsRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateAdminCommandResponse>> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            if (!await _applicationUsersRepository.IsEmailUniqueAsync(request.Email))
                return Result.Failure<CreateAdminCommandResponse>(ApplicationUserErrors.ApplicationUserAlreadyExists(request.Email));

            var passwordHash = _passwordService.HashPassword(request.Password);

            var admin = Admin.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, passwordHash);

            await _adminsRepository.CreateAsync(admin);

            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);

            return _mapper.Map<CreateAdminCommandResponse>(admin);
        }
    }
}
