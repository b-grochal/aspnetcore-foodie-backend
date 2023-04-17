using MediatR;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.DeleteCustomerBasket
{
    public class DeleteCustomerBasketCommand : IRequest
    {
        public string CustomerId { get; set; }

        public DeleteCustomerBasketCommand(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
