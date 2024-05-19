using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommand : IAuditableCommand, IRequest<Result<CreateCityCommandResponse>>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string User { get; set; }
    }
}
