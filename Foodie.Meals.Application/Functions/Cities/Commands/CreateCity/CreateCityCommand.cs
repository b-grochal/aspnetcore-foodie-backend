using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommand : AuditableCreateCommand, IRequest<CreateCityCommandResponse>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
