using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest
    {
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int LocationId { get; set; }
        public string LocationAddress { get; set; }
        public string LocationPhoneNumber { get; set; }
        public string LocationEmail { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string LocationCountry { get; set; }
        private readonly List<OrderItemDTO> _orderItems;
        public IEnumerable<OrderItemDTO> OrderItems => _orderItems;

        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDTO>();
        }

        public record OrderItemDTO
        {
            public int MealId { get; init; }
            public string MealName { get; init; }
            public decimal UnitPrice { get; init; }
            public int Units { get; init; }
        }
    }
}
