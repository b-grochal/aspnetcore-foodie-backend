using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : AuditableCreateCommand, IRequest<CreateCountryCommandResponse>
    {
        public string Name { get; set; }
    }
}
