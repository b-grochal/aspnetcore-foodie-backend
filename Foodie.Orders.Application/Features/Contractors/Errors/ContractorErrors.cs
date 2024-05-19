using Foodie.Common.Results;

namespace Foodie.Orders.Application.Features.Contractors.Errors
{
    public static class ContractorErrors
    {
        public static Error ContractorNotFoundById(int id) =>
            Error.NotFound("Contractors.ContractorNotFoundById",
                $"The contractor with the identifier {id} was not found.");
    }
}
