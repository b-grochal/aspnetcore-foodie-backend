using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommand : IAuditableCommand, IRequest<CreateCityCommandResponse>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string User { get; set; }
    }
}
