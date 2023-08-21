using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
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
            var orderHandler = await orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.Id);

            var updatedOrderHandler = mapper.Map(request, orderHandler);
            await orderHandlersRepository.UpdateAsync(updatedOrderHandler);

            return mapper.Map<UpdateOrderHandlerCommandResponse>(updatedOrderHandler);
        }
    }
}
