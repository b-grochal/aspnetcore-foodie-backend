using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Commands.CreateAdmin
{
    public class CreateAdminCommandValidator : AbstractValidator<CreateAdminCommand>
    {
        public CreateAdminCommandValidator()
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

            RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .EmailAddress()
            .WithMessage("Invalid email address");

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
