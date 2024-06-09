using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Customers;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CreateCustomerCommandResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository,
                                            IApplicationUsersRepository applicationUsersRepository,
                                            IPasswordService passwordService,
                                            IMapper mapper,
                                            ICacheService cacheService,
                                            IBackgroundJobClient backgroundJobClient,
                                            IEmailsService emailsService, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateCustomerCommandResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!await _applicationUsersRepository.IsEmailUniqueAsync(request.Email))
                return Result.Failure<CreateCustomerCommandResponse>(ApplicationUserErrors.ApplicationUserAlreadyExists(request.Email));

            var passwordHash = _passwordService.HashPassword(request.Password);

            var customer = Customer.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, passwordHash);

            await _customersRepository.CreateAsync(customer);

            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);

            return _mapper.Map<CreateCustomerCommandResponse>(customer);
        }
    }
}
