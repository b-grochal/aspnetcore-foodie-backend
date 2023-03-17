using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQueryResponse
    {
        public int Id { get; set; }
        public int RestaurantId { get; private set; }
        public string Name { get; private set; }
        public int LocationId { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int CityId { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
    }
}
