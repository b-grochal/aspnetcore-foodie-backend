using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : AuditableCommand, IRequest<CreateCountryCommandResponse>
    {
        public string Name { get; set; }
    }
}
