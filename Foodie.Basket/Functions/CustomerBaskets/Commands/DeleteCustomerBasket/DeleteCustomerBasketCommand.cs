using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket
{
    public class DeleteCustomerBasketCommand : IRequest
    {
        public int CustomerId { get; set; }

        public DeleteCustomerBasketCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
