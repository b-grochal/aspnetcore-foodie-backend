using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommand : AuditableCommand, IRequest<CreateCityCommandResponse>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
