using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetInProgressOrderStatus
{
    public class SetInProgressOrderStatusCommandHandler : IRequestHandler<SetInProgressOrderStatusCommand, Result>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetInProgressOrderStatusCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetInProgressOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order is null)
                return Result.Failure(OrderErrors.OrderNotFoundById(request.Id));

            order.SetInProgressStatus();
            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);

            return Result.Success();
        }
    }
}
