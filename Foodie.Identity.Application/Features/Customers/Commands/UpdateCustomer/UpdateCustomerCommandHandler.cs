using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<UpdateCustomerCommandResponse>>
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

        public async Task<Result<UpdateCustomerCommandResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetByIdAsync(request.Id);

            if (customer is null)
                return Result.Failure<UpdateCustomerCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            customer.Update(request.FirstName, request.LastName, request.Email, request.Email);

            await _customersRepository.UpdateAsync(customer);

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return _mapper.Map<UpdateCustomerCommandResponse>(customer);
        }
    }
}
