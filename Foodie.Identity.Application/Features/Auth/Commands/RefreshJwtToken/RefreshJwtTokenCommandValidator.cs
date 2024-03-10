using FluentValidation;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommandValidator : AbstractValidator<RefreshJwtTokenCommand>
    {
        public RefreshJwtTokenCommandValidator()
        {
            RuleFor(c => c.JwtToken)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.RefreshToken)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
