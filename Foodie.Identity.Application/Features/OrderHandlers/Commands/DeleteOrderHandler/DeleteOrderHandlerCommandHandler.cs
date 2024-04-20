using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommandHandler : IRequestHandler<DeleteOrderHandlerCommand, Result<DeleteOrderHandlerCommandResponse>>
    {
        private readonly IOrderHandlersRepository _orderHandlersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandlerCommandHandler(IOrderHandlersRepository orderHandlersRepository, IUnitOfWork unitOfWork)
        {
            _orderHandlersRepository = orderHandlersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteOrderHandlerCommandResponse>> Handle(DeleteOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = await _orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler is null)
                return Result.Failure<DeleteOrderHandlerCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            await _orderHandlersRepository.DeleteAsync(orderHandler);

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return new DeleteOrderHandlerCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
