using FluentValidation;
using Foodie.Common.Application.Behaviours;
using Foodie.Common.Exceptions;
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
                    .Select(x => $"{x.PropertyName} - {x.ErrorMessage}.");

                if (errors.Any())
                    return (TResponse)Result.Failure(BehavioursErrors.InvalidData(string.Join(' ', errors)));
            }
            return await next();
        }
    }
}
