using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Domain.Results;
using Foodie.Common.Enums;
using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Exceptions;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using Foodie.Identity.Domain.Customers;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.Auth.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result<SignUpCommandResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpCommandHandler(ICustomersRepository customersRepository,
                                    IApplicationUsersRepository applicationUsersRepository,
                                    IRefreshTokensRepository refreshTokensRepository,
                                    IPasswordService passwordService,
                                    IMapper mapper,
                                    ICacheService cacheService,
                                    IBackgroundJobClient backgroundJobClient,
                                    IEmailsService emailsService, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _refreshTokensRepository = refreshTokensRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SignUpCommandResponse>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            if (!await _applicationUsersRepository.IsEmailUniqueAsync(request.Email))
                return Result.Failure<SignUpCommandResponse>(ApplicationUserErrors.ApplicationUserAlreadyExists(request.Email));

            var passwordHash = _passwordService.HashPassword(request.Password);

            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, passwordHash);

            await _customersRepository.CreateAsync(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SignUpCommandResponse>(customer);
        }
    }
}
