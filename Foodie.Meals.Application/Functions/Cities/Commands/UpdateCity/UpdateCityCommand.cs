using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : AuditableCommand, IRequest<UpdateCityCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
