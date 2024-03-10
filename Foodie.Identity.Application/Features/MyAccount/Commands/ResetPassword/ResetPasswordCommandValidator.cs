using FluentValidation;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .EmailAddress()
            .WithMessage("Invalid email address");
        }
    }
}
