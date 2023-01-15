using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler
{
    public class UpdateOrderHandlerCommandHandler : IRequestHandler<UpdateOrderHandlerCommand, UpdateOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository orderHandlersRepository;
        private readonly IMapper mapper;

        public UpdateOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper)
        {
            this.orderHandlersRepository = orderHandlersRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateOrderHandlerCommandResponse> Handle(UpdateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = await orderHandlersRepository.GetByIdAsync(request.OrderHandlerId);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.OrderHandlerId);

            var updatedOrderHandler = mapper.Map(request, orderHandler);
            var identityResult = await orderHandlersRepository.UpdateAsync(updatedOrderHandler);

            if(!identityResult.Succeeded)
                throw new ApplicationUserNotUpdatedException(updatedOrderHandler.Id);

            return mapper.Map<UpdateOrderHandlerCommandResponse>(updatedOrderHandler);
        }
    }
}
