using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
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
        private readonly IMapper mapper;

        public CreateOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.mapper = mapper;
        }

        public async Task<CreateOrderHandlerCommandResponse> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = mapper.Map<OrderHandler>(request);
            orderHandler.EmailConfirmed = true;
            orderHandler.PhoneNumberConfirmed = true;

            await orderHandlersRepository.CreateAsync(orderHandler, request.Password);
            return mapper.Map<CreateOrderHandlerCommandResponse>(orderHandler);
        }
    }
}
