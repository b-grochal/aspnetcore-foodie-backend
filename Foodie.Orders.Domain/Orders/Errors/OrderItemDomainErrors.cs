using Foodie.Common.Results;

namespace Foodie.Orders.Domain.Orders.Errors
{
    public static class OrderItemDomainErrors
    {
        public static Error QuantityLoweThanZero() =>
            Error.Failure("OrderItems.QuantityLoweThanZero",
                "Quantity should be greater than zero.");
    }
}
