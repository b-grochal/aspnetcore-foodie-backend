using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler
{
    public class CreateOrderHandlerCommandHandler : IRequestHandler<CreateOrderHandlerCommand, CreateOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IApplicationUserRolesRepository applicationUserRolesRepository;
        private readonly IMapper mapper;

        public CreateOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IApplicationUserRolesRepository applicationUserRolesRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.applicationUserRolesRepository = applicationUserRolesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateOrderHandlerCommandResponse> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = mapper.Map<OrderHandler>(request);

            orderHandler.EmailConfirmed = true;
            orderHandler.PhoneNumberConfirmed = true;

            var identityResult = await orderHandlersRepository.CreateAsync(orderHandler, request.Password);

            if (!identityResult.Succeeded)
                throw new ApplicationUserNotCreatedException();

            identityResult = await applicationUserRolesRepository.CreateApplicationUserRole(orderHandler, ApplicationUserRoles.OrderHandler);

            if (!identityResult.Succeeded)
                throw new ApplicationUserRoleNotCreatedException(orderHandler.Id, ApplicationUserRoles.OrderHandler);

            return mapper.Map<CreateOrderHandlerCommandResponse>(orderHandler);
        }
    }
}
