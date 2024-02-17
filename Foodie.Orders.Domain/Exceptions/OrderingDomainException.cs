using Foodie.Common.Exceptions;

namespace Foodie.Orders.Domain.Exceptions
{
    public class OrderingDomainException : BadRequestException
    {
        public OrderingDomainException(string message) : base(message) { }
    }
}
