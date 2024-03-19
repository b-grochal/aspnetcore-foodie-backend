using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Admins;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Result<CreateAdminCommandResponse>>
    {
        private readonly IAdminsRepository _adminsRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IRefreshTokensRepository _applicationUserRefreshTokensRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;

        public CreateAdminCommandHandler(IAdminsRepository adminsRepository, IApplicationUsersRepository applicationUsersRepository, IRefreshTokensRepository applicationUserRefreshTokensRepository, IPasswordService passwordService, IMapper mapper, ICacheService cacheService, IBackgroundJobClient backgroundJobClient, IEmailsService emailsService, IUnitOfWork unitOfWork)
        {
            _adminsRepository = adminsRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _applicationUserRefreshTokensRepository = applicationUserRefreshTokensRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateAdminCommandResponse>> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            if (!await _applicationUsersRepository.IsEmailUniqueAsync(request.Email))
                return Result.Failure<CreateAdminCommandResponse>(ApplicationUserErrors.ApplicationUserAlreadyExists(request.Email));

            var passwordHash = _passwordService.HashPassword(request.Password);

            var admin = Admin.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, passwordHash);

            await _adminsRepository.CreateAsync(admin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateAdminCommandResponse>(admin);
        }
    }
}
