using Foodie.Common.Results;

namespace Foodie.Common.Application.Behaviours
{
    public static class BehavioursErrors
    {
        public static Error InvalidRequestData(string message) =>
            Error.Validation("RequestValidation.InvalidRequestData", message);

        public static Error UnauthorizedRequest(string message) =>
            Error.Unauthorized("RequestAuthorization.UnauthorizedRequest", message);
    }
}
