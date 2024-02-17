using Foodie.Common.Exceptions;

namespace Foodie.Orders.Domain.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int orderId) : base($"The order with the indetifier {orderId} was not found.") { }
    }
}
