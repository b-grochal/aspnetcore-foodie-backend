using FluentValidation;

namespace Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal
{
    public class CreateMealCommandValidator : AbstractValidator<CreateMealCommand>
    {
        public CreateMealCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(m => m.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(m => m.RestaurantId)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");
        }
    }
}
