using FluentValidation;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ActivateAccount
{
    public class ActivateAccountCommandValidator : AbstractValidator<ActivateAccountCommand>
    {
        public ActivateAccountCommandValidator()
        {
            RuleFor(c => c.AccountActivationToken)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
