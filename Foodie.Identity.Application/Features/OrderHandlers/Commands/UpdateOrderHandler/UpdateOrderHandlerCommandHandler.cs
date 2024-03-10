using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler
{
    public class UpdateOrderHandlerCommandHandler : IRequestHandler<UpdateOrderHandlerCommand, UpdateOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository _orderHandlersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _orderHandlersRepository = orderHandlersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOrderHandlerCommandResponse> Handle(UpdateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = await _orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.Id);

            var updatedOrderHandler = _mapper.Map(request, orderHandler);
            await _orderHandlersRepository.UpdateAsync(updatedOrderHandler);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateOrderHandlerCommandResponse>(updatedOrderHandler);
        }
    }
}
