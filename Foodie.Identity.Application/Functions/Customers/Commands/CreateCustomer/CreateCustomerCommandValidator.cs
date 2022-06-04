using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
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
            .Equal(c => c.Email)
            .WithMessage("Passwords do not match");
        }
    }
}
