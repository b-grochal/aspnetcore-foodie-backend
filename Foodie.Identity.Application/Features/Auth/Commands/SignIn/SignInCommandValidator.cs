using FluentValidation;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .EmailAddress()
            .WithMessage("Invalid email address");

            RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
