using Foodie.Common.Results;

namespace Foodie.Orders.Application.Features.Buyers.Errors
{
    public static class BuyerErrors
    {
        public static Error BuyerNotFoundById(int id) =>
            Error.NotFound("Buyers.BuyerNotFoundById",
                $"The buyer with the identifier {id} was not found.");
    }
}
