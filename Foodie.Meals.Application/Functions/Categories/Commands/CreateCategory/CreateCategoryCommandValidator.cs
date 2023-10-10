using FluentValidation;

namespace Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
