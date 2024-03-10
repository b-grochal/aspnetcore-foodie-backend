using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Enums;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Exceptions;
using Foodie.Identity.Domain.Entities;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreateAdminCommandResponse>
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

        public async Task<CreateAdminCommandResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            if ((await _applicationUsersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var admin = _mapper.Map<Admin>(request);

            admin.PasswordHash = _passwordService.HashPassword(request.Password);
            admin.Role = ApplicationUserRole.Admin;

            await _adminsRepository.CreateAsync(admin);

            await _applicationUserRefreshTokensRepository.CreateAsync(new RefreshToken
            {
                ApplicationUserId = admin.Id,
                Token = null,
                ExpirationTime = null
            });

            var accountActivationToken = Guid.NewGuid().ToString();
            await _cacheService.SetAsync<ApplicationUser>(admin,
                                                          CachePrefixes.AccountActivationTokens,
                                                          string.Empty,
                                                          CacheParameters.AccountActivationToken,
                                                          accountActivationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _backgroundJobClient.Enqueue(() => _emailsService.SendAccountActivationEmail(admin.Email, accountActivationToken));

            return _mapper.Map<CreateAdminCommandResponse>(admin);
        }
    }
}
