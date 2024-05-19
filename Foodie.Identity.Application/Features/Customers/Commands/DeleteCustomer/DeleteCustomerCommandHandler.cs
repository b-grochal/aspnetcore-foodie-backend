using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer
{
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<DeleteCustomerCommandResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteCustomerCommandResponse>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetByIdAsync(request.Id);

            if (customer is null)
                return Result.Failure<DeleteCustomerCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            await _customersRepository.DeleteAsync(customer);

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return new DeleteCustomerCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
