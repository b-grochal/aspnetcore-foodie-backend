using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommand : AuditableCommand, IRequest<UpdateLocationCommandResponse>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public int RestaurantId { get; set; }
    }
}
