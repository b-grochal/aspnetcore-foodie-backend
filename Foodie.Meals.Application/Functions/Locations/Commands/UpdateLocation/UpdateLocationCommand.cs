using Foodie.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommand : AuditableUpdateCommand, IRequest<UpdateLocationCommandResponse>
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public int RestaurantId { get; set; }
    }
}
