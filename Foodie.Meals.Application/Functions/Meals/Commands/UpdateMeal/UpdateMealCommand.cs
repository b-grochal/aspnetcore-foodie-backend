using Foodie.Common.Application.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommand : AuditableCommand, IRequest<UpdateMealCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
