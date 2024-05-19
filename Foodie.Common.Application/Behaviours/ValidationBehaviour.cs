using FluentValidation;
using Foodie.Common.Application.Behaviours;
using Foodie.Common.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
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
                    .Select(x => new ErrorDetail(x.PropertyName, x.ErrorMessage))
                    .ToList();

                if (errors.Any())
                    return CreateValidationResult<TResponse>(errors);
            }

            return await next();
        }

        private TResult CreateValidationResult<TResult>(IReadOnlyCollection<ErrorDetail> errors)
            where TResult : Result
        {
            if (typeof(TResult) == typeof(Result))
            {
                return (Result.Failure(BehavioursErrors.InvalidRequestData("Invalid request data.", errors)) as TResult)!;
            }

            object validationResult = typeof(Result<>)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .BaseType
                .GetMethods()
                .Single(m => m.Name == nameof(Result.Failure) && m.IsGenericMethodDefinition)
                .MakeGenericMethod(typeof(TResult).GenericTypeArguments[0])
                .Invoke(null, [BehavioursErrors.InvalidRequestData("Invalid request data.", errors)]);

            return (TResult)validationResult;
        }
    }
}
