using FluentValidation;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ActivateAccount
{
    public class ActivateAccountCommandValidator : AbstractValidator<ActivateAccountCommand>
    {
        public ActivateAccountCommandValidator()
        {
            RuleFor(c => c.Token)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
