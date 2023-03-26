using Foodie.Shared.Exceptions;

namespace Foodie.Basket.API.Exceptions
{
    public class CustomerBasketNotFound : NotFoundException
    {
        public CustomerBasketNotFound(string customerId) : base($"The basket for the customer's indetifier {customerId} was not found.") { }
    }
}
