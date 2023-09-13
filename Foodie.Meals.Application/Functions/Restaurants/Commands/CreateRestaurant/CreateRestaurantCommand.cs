using Foodie.Shared.Commands;
using MediatR;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : AuditableCreateCommand, IRequest<CreateRestaurantCommandResponse>
    {
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoriesIds { get; set; }
    }
}
