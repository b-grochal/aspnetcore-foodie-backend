using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommandHandler : IRequestHandler<SetInDeliveryOrderStatusCommand, Result>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetInDeliveryOrderStatusCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetInDeliveryOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order is null)
                return Result.Failure(OrderErrors.OrderNotFoundById(request.Id));

            order.SetInDeliveryStatus();

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);
            return Result.Success();
        }
    }
}
