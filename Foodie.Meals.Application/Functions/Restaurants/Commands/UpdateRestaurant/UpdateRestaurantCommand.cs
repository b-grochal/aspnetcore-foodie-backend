using Foodie.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : AuditableUpdateCommand, IRequest<UpdateRestaurantCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoryIds { get; set; }
    }
}
