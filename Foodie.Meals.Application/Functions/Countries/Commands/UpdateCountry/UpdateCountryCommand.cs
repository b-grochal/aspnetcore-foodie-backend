using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : AuditableUpdateCommand, IRequest<UpdateCountryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
