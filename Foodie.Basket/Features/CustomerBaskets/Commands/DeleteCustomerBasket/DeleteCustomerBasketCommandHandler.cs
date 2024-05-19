using Foodie.Basket.Repositories.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket
{
    public class DeleteCustomerBasketCommandHandler : IRequestHandler<DeleteCustomerBasketCommand, Result>
    {
        private readonly ICustomerBasketsRepository customerBasketsRepository;

        public DeleteCustomerBasketCommandHandler(ICustomerBasketsRepository customerBasketsRepository)
        {
            this.customerBasketsRepository = customerBasketsRepository;
        }

        public async Task<Result> Handle(DeleteCustomerBasketCommand request, CancellationToken cancellationToken)
        {
            await customerBasketsRepository.DeleteBasket(request.ApplicationUserId);
            return Result.Success();
        }
    }
}
