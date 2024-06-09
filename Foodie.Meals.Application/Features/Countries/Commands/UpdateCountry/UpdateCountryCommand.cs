using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IAuditableCommand, IRequest<Result<UpdateCountryCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
