using FluentValidation;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket
{
    public class UpdateCustomerBasketCommandValidator : AbstractValidator<UpdateCustomerBasketCommand>
    {
        public UpdateCustomerBasketCommandValidator()
        {
            RuleFor(c => c.LocationId)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.Items)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
