﻿namespace Foodie.Identity.Application.Features.Auth.Commands.SignUp
{
    public class SignUpCommandResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}