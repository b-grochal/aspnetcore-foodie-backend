﻿using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class InvalidAccountActivationTokenException : BadRequestException
    {
        public InvalidAccountActivationTokenException() : base($"Invalid account activation token.") { }
    }
}
