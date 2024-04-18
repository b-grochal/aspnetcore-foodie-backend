using AutoMapper.Internal;
using FluentValidation;
using Foodie.Common.Application.Behaviours;
using Foodie.Common.Exceptions;
using Foodie.Common.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Shared.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var errors = validators
                    .Select(x => x.Validate(context))
                    .SelectMany(x => x.Errors)
                    .Where(x => x != null)
                    .Select(x => $"{x.PropertyName} - {x.ErrorMessage}.")
                    .ToList();

                if (errors.Any())
                    return CreateValidationResult<TResponse>(errors);
            }

            return await next();
        }

        private TResult CreateValidationResult<TResult>(IEnumerable<string> errors)
            where TResult : Result
        {
            if(typeof(TResult) == typeof(Result))
            {
                return (Result.Failure(BehavioursErrors.InvalidRequestData("Invalid request data.", errors.ToList())) as TResult)!;
            }

            var x1 = typeof(Result<>)
                .GetGenericTypeDefinition();
            var t = typeof(TResult);
            var x2 = x1.MakeGenericType(typeof(TResult).GenericTypeArguments[0]);
            var x24 = nameof(Result.Failure);
            var x25 = x2.GetRuntimeMethods();
            var x256213 = x2.GetMethods(BindingFlags.FlattenHierarchy);
            var x256 = x2.GetMethod(nameof(Result.Failure), BindingFlags.FlattenHierarchy);
            var x257 = x2.BaseType.GetMethods()
              .Single(m => m.Name == "Failure" && m.IsGenericMethodDefinition);
            var x3 = x2.GetMethod("Failure", new[] { typeof(Error) })!;

            var x4 = x257.MakeGenericMethod(typeof(TResult).GenericTypeArguments[0]).Invoke(null, new object[] { BehavioursErrors.InvalidRequestData("Invalid request data.", errors.ToList()) });

            //object validationResult = typeof(Result<>)
            //    .GetGenericTypeDefinition()
            //    .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            //    .GetMethod(nameof(Result.Failure))!
            //    .Invoke(null,  new object[] { BehavioursErrors.InvalidRequestData("Invalid request data.", errors.ToList()) });

            return (TResult)x4;
        }
    }
}
