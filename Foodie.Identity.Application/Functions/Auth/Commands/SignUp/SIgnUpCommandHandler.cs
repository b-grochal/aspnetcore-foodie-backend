using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Application.Exceptions;
using Foodie.Shared.Cache;
using Foodie.Shared.Enums;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpCommandResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;

        public SignUpCommandHandler(ICustomersRepository customersRepository,
                                    IApplicationUsersRepository applicationUsersRepository,
                                    IRefreshTokensRepository refreshTokensRepository,
                                    IPasswordService passwordService,
                                    IMapper mapper,
                                    ICacheService cacheService,
                                    IBackgroundJobClient backgroundJobClient,
                                    IEmailsService emailsService)
        {
            _customersRepository = customersRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _refreshTokensRepository = refreshTokensRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
        }

        public async Task<SignUpCommandResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            if((await _applicationUsersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var customer = _mapper.Map<Customer>(request);
            customer.PasswordHash = _passwordService.HashPassword(request.Password);
            customer.Role = ApplicationUserRole.Customer;

            await _customersRepository.CreateAsync(customer);

            await _refreshTokensRepository.CreateAsync(new RefreshToken
            {
                ApplicationUserId = customer.Id,
                Token = null,
                ExpirationTime = null
            });

            var accountActivationToken = Guid.NewGuid().ToString();
            await _cacheService.SetAsync<ApplicationUser>(customer,
                                                          CachePrefixes.AccountActivationTokens,
                                                          string.Empty,
                                                          CacheParameters.AccountActivationToken,
                                                          accountActivationToken);
            _backgroundJobClient.Enqueue(() => _emailsService.SendAccountActivationEmail(customer.Email, accountActivationToken));

            return _mapper.Map<SignUpCommandResponse>(customer);
        }
    }
}
