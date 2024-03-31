using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IAuditableCommand, IRequest<UpdateCountryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
    }
}
