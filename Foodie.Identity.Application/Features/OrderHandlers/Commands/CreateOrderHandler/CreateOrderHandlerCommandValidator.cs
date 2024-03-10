using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler
{
    public class CreateOrderHandlerCommandValidator : AbstractValidator<CreateOrderHandlerCommand>
    {
        public CreateOrderHandlerCommandValidator()
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
            .WithMessage("Invalid email address")
            .Must(email => email.EndsWith("@foodie.com"))
            .When(c => c.Email is not null, ApplyConditionTo.CurrentValidator)
            .WithMessage("Only emails in foodie.com domain are allowed for order handlers");

            RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .Equal(c => c.Password)
            .WithMessage("Passwords do not match");

            RuleFor(c => c.LocationId)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
