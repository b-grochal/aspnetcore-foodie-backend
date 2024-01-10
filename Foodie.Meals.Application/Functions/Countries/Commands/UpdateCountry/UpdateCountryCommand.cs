using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : AuditableCommand, IRequest<UpdateCountryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
