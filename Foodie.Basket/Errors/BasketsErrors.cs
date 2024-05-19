using Foodie.Common.Results;

namespace Foodie.Basket.API.Errors
{
    public static class BasketsErrors
    {
        public static Error BasketNotFoundByApplicationUserId(int id) =>
            Error.NotFound("Baskets.BasketNotFoundByApplicationUserId",
                $"The basket for the applicatio user with the identifier {id} was not found.");
    }
}
