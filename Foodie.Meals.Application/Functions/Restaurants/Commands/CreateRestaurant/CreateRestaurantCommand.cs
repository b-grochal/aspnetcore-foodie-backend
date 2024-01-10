using Foodie.Common.Application.Commands;
using MediatR;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : AuditableCommand, IRequest<CreateRestaurantCommandResponse>
    {
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoriesIds { get; set; }
    }
}
