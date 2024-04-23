using Foodie.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace Foodie.Common.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;

        protected BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected IActionResult HandleFailure(Result result)
        {
            if (result.IsSucess)
            {
                throw new InvalidOperationException();
            }

            if (result.Error.Type == ErrorType.Validation)
            {
                return ValidationProblem(result.Error.Details);
            }

            if (result.Error.Details is not null)
            {
                HttpContext.Items["errorDetails"] = result.Error.Details;
            }

            return Problem(
                statusCode: GetStatusCodeForFailedResult(result),
                title: GetTitleForFailedResult(result),
                type: GetTypeForFailedResult(result),
                detail: GetDescriptionForFailedResult(result));
        }

        private IActionResult ValidationProblem(IReadOnlyCollection<ErrorDetail> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Title,
                    error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

        private int GetStatusCodeForFailedResult(Result result) =>
            result.Error.Type switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

        private string GetTitleForFailedResult(Result result) =>
            result.Error.Type switch
            {
                ErrorType.Validation => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                ErrorType.Unauthorized => "Unauthorized",
                _ => "Server failure"
            };

        private string GetTypeForFailedResult(Result result) =>
            result.Error.Type switch
            {
                ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                ErrorType.Unauthorized => "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            };

        private string GetDescriptionForFailedResult(Result result) =>
            result.Error.Description;
    }
}
