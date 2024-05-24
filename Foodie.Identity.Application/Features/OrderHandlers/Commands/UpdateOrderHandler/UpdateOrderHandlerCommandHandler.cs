using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler
{
    public class UpdateOrderHandlerCommandHandler : IRequestHandler<UpdateOrderHandlerCommand, Result<UpdateOrderHandlerCommandResponse>>
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

        public async Task<Result<UpdateOrderHandlerCommandResponse>> Handle(UpdateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            var orderHandler = await _orderHandlersRepository.GetByIdAsync(request.Id);

            if (orderHandler is null)
                return Result.Failure<UpdateOrderHandlerCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            orderHandler.Update(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.LocationId);

            await _orderHandlersRepository.UpdateAsync(orderHandler);

            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);

            return _mapper.Map<UpdateOrderHandlerCommandResponse>(orderHandler);
        }
    }
}
