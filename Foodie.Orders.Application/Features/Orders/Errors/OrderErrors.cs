using Foodie.Common.Results;

namespace Foodie.Orders.Application.Features.Orders.Errors
{
    public static class OrderErrors
    {
        public static Error OrderNotFoundById(int id) =>
            Error.NotFound("Orders.OrderNotFoundById",
                $"The order with the identifier {id} was not found.");

        public static Error CustomersOrderNotFoundById(int id, int customerId) =>
            Error.NotFound("Orders.OrderNotFoundById",
                $"The order with the identifier {id} was not found for the customer with identifier {customerId}.");
    }
}
