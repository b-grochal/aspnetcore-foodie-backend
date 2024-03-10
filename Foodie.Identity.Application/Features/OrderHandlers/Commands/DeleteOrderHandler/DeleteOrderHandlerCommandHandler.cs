using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommandHandler : IRequestHandler<DeleteOrderHandlerCommand, DeleteOrderHandlerCommandResponse>
    {
        private readonly IOrderHandlersRepository _orderHandlersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IUnitOfWork unitOfWork)
        {
            _orderHandlersRepository = orderHandlersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteOrderHandlerCommandResponse> Handle(DeleteOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = await _orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler == null)
                throw new ApplicationUserNotFoundException(request.Id);

            await _orderHandlersRepository.DeleteAsync(orderHandler);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteOrderHandlerCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
