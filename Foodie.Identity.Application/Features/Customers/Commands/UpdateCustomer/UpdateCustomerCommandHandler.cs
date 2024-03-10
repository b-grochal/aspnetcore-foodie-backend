using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomersRepository customersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new ApplicationUserNotFoundException(request.Id);

            var updatedCustomer = _mapper.Map(request, customer);
            await _customersRepository.UpdateAsync(updatedCustomer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateCustomerCommandResponse>(updatedCustomer);
        }
    }
}
