using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IAuditableCommand, IRequest<Result<CreateCountryCommandResponse>>
    {
        public string Name { get; set; }
        public string User { get; set; }
    }
}
