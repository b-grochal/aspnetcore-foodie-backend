using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IAuditableCommand, IRequest<CreateCountryCommandResponse>
    {
        public string Name { get; set; }
        public string User { get; set; }
    }
}
