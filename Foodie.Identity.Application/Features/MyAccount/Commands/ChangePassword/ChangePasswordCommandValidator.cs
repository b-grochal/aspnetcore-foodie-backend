using FluentValidation;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .Equal(c => c.Password)
            .WithMessage("Passwords do not match");
        }
    }
}
