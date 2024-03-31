using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetDeliveredOrderStatus
{
    public class SetDeliveredOrderStatusCommandHandler : IRequestHandler<SetDeliveredOrderStatusCommand, Result>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetDeliveredOrderStatusCommandHandler(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetDeliveredOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(request.Id);

            if (order is null)
                return Result.Failure(OrderErrors.OrderNotFoundById(request.Id));

            order.SetDeliveredStatus();

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
