﻿namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler
{
    public class UpdateOrderHandlerCommandResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
    }
}
