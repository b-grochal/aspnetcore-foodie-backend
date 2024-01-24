using Foodie.Common.Exceptions;
using Foodie.Shared.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Foodie.Common.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var responseDetails = PrepareResponseDetails(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = responseDetails.StatusCode;

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = responseDetails.StatusCode,
                Message = responseDetails.Message,
                Errors = responseDetails.Errors
            }.ToString());
        }

        private (string Message, int StatusCode, IReadOnlyDictionary<string, string[]> Errors) PrepareResponseDetails(Exception exception)
        {
            return exception switch
            {
                NotFoundException => (exception.Message, (int)HttpStatusCode.NotFound, null),
                BadRequestException => (exception.Message, (int)HttpStatusCode.BadRequest, null),
                InternalServerErrorException => (exception.Message, (int)HttpStatusCode.InternalServerError, null),
                ValidationFailureException ex => (exception.Message, (int)HttpStatusCode.BadRequest, ex.ErrorsDictionary),
                UnauthorizedException => (exception.Message, (int)HttpStatusCode.Unauthorized, null),
                _ => ("Internal server error", (int)HttpStatusCode.InternalServerError, null)
            };
        }
    }

    // Change it to Problem Details class
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IReadOnlyDictionary<string, string[]> Errors { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
