using Foodie.Shared.Exceptions;

namespace Foodie.Basket.API.Exceptions
{
    public class CustomerBasketNotFoundException : NotFoundException
    {
        public CustomerBasketNotFoundException(string customerId) : base($"The basket for the customer's indetifier {customerId} was not found.") { }
    }
}
