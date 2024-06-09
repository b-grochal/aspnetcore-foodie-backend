using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : IAuditableCommand, IRequest<Result<UpdateCityCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
