using FluentValidation;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.CountryId)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
