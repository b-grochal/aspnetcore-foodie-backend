using Foodie.Common.Application.Commands;
using MediatR;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : AuditableCommand, IRequest<UpdateRestaurantCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoriesIds { get; set; }
    }
}
