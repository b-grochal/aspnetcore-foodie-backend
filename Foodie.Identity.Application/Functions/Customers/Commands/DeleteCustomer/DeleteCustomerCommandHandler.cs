using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer
{
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new ApplicationUserNotFoundException(request.Id);

            await _customersRepository.DeleteAsync(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
