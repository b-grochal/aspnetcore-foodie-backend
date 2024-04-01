using FluentValidation;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.CheckoutCustomerBasket
{
    public class CheckoutCustomerBasketCommandValidator : AbstractValidator<CheckoutCustomerBasketCommand>
    {
        public CheckoutCustomerBasketCommandValidator()
        {
            RuleFor(c => c.Address)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.ApplicationUserId)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
