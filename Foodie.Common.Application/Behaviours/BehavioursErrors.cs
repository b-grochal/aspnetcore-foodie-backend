using Foodie.Common.Results;
using System.Collections.Generic;

namespace Foodie.Common.Application.Behaviours
{
    public static class BehavioursErrors
    {
        public static Error InvalidRequestData(string message, IReadOnlyCollection<ErrorDetail> details) =>
            Error.Validation("RequestValidation.InvalidRequestData", message, details);

        public static Error UnauthorizedRequest(string message) =>
            Error.Unauthorized("RequestAuthorization.UnauthorizedRequest", message);
    }
}
