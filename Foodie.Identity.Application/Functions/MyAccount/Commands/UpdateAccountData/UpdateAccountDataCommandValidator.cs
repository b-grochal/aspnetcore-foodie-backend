using FluentValidation;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.UpdateAccountData
{
    public class UpdateAccountDataCommandValidator : AbstractValidator<UpdateAccountDataCommand>
    {
        public UpdateAccountDataCommandValidator()
        {
            RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
