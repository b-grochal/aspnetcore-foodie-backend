using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using Foodie.Shared.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler
{
    public class CreateOrderHandlerCommandHandler : IRequestHandler<CreateOrderHandlerCommand, CreateOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IApplicationUserRefreshTokensRepository applicationUserRefreshTokensRepository;
        private readonly IPasswordService passwordService;
        private readonly IMapper mapper;

        public CreateOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IApplicationUsersRepository applicationUsersRepository, IApplicationUserRefreshTokensRepository applicationUserRefreshTokensRepository, IPasswordService passwordService, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.applicationUsersRepository = applicationUsersRepository;
            this.applicationUserRefreshTokensRepository = applicationUserRefreshTokensRepository;
            this.passwordService = passwordService;
            this.mapper = mapper;
        }

        public async Task<CreateOrderHandlerCommandResponse> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            if ((await applicationUsersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var orderHandler = mapper.Map<OrderHandler>(request);

            orderHandler.PasswordHash = passwordService.HashPassword(request.Password);
            orderHandler.Role = ApplicationUserRole.OrderHandler;

            await orderHandlersRepository.CreateAsync(orderHandler);

            await applicationUserRefreshTokensRepository.CreateAsync(new ApplicationUserRefreshToken
            {
                ApplicationUserId = orderHandler.Id,
                Token = null,
                ExpirationTime = null
            });

            return mapper.Map<CreateOrderHandlerCommandResponse>(orderHandler);
        }
    }
}
