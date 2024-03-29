﻿using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommandHandler : IRequestHandler<DeleteOrderHandlerCommand, DeleteOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;

        public DeleteOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository)
        {
            this.orderHandlersRepository = orderHandlersRepository;
        }

        public async Task<DeleteOrderHandlerCommandResponse> Handle(DeleteOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = await orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.Id);

            await orderHandlersRepository.DeleteAsync(orderHandler);

            return new DeleteOrderHandlerCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
