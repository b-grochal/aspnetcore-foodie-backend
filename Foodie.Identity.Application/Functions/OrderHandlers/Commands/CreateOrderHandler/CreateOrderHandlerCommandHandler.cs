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

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler
{
    public class CreateOrderHandlerCommandHandler : IRequestHandler<CreateOrderHandlerCommand, CreateOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository _orderHandlersRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IEmailsService _emailsService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IApplicationUsersRepository applicationUsersRepository, IRefreshTokensRepository refreshTokensRepository, IPasswordService passwordService, IMapper mapper, ICacheService cacheService, IBackgroundJobClient backgroundJobClient, IEmailsService emailsService, IUnitOfWork unitOfWork)
        {
            _orderHandlersRepository = orderHandlersRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _refreshTokensRepository = refreshTokensRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _cacheService = cacheService;
            _backgroundJobClient = backgroundJobClient;
            _emailsService = emailsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateOrderHandlerCommandResponse> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            if ((await _applicationUsersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var orderHandler = _mapper.Map<OrderHandler>(request);

            orderHandler.PasswordHash = _passwordService.HashPassword(request.Password);
            orderHandler.Role = ApplicationUserRole.OrderHandler;

            await _orderHandlersRepository.CreateAsync(orderHandler);

            await _refreshTokensRepository.CreateAsync(new RefreshToken
            {
                ApplicationUserId = orderHandler.Id,
                Token = null,
                ExpirationTime = null
            });

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var accountActivationToken = Guid.NewGuid().ToString();
            await _cacheService.SetAsync<ApplicationUser>(orderHandler,
                                                          CachePrefixes.AccountActivationTokens,
                                                          string.Empty,
                                                          CacheParameters.AccountActivationToken,
                                                          accountActivationToken);
            _backgroundJobClient.Enqueue(() => _emailsService.SendAccountActivationEmail(orderHandler.Email, accountActivationToken));

            return _mapper.Map<CreateOrderHandlerCommandResponse>(orderHandler);
        }
    }
}
