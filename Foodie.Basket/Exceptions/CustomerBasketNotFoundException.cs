using Foodie.Common.Exceptions;

namespace Foodie.Basket.API.Exceptions
{
    public class CustomerBasketNotFoundException : NotFoundException
    {
        public CustomerBasketNotFoundException(int customerId) : base($"The basket for the customer's indetifier {customerId} was not found.") { }
    }
}
