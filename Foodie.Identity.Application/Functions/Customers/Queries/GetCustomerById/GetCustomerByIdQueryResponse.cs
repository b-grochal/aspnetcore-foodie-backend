﻿namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
