using Foodie.Common.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Foodie.Common.Api.Results
{
    public static class ResultsExtensions
    {
        public static ProblemDetails ToProblemDetails(this Result result)
        {
            throw new NotImplementedException();
        }

        private static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetTitle(this Result result) =>
            result.Error.Type switch
            {
                ErrorType.Validation => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                ErrorType.Unauthorized => "Unauthorized",
                _ => "Server failure"
            };

        private static string GetType(this Result result) =>
            result.Error.Type switch
            {
                ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                ErrorType.Unauthorized => "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            };
    }
}
