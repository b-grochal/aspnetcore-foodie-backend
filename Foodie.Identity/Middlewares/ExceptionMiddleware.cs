using FluentValidation;
using Foodie.Identity.API.Models;
using Foodie.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Foodie.Identity.API.Middlewares
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
                Message = responseDetails.Message
            }.ToString());
        }

        private (string Message, int StatusCode) PrepareResponseDetails(Exception exception)
        {
            return exception switch
            {
                NotFoundException => (exception.Message, (int)HttpStatusCode.NotFound),
                BadRequestException => (exception.Message, (int)HttpStatusCode.BadRequest),
                InternalServerErrorException => (exception.Message, (int)HttpStatusCode.InternalServerError),
                ValidationException => (exception.Message, (int)HttpStatusCode.BadRequest),
                _ => ("Internal server error", (int)HttpStatusCode.InternalServerError)
            };
        }
    }
}
