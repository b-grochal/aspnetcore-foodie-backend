using Foodie.Common.Results;

namespace Foodie.Common.Application.Behaviours
{
    public static class BehavioursErrors
    {
        public static Error InvalidData(string message) =>
            Error.Validation("Validation.InvalidData", message);

        public static Error UnauthorizedRequest(string message) =>
            Error.Unauthorized("Authorization.UnauthorizedRequest", message);
    }
}
