using AutoMapper;
using Foodie.Meals.Commands.Restaurants;
using Foodie.Meals.Models;
using Foodie.Meals.Responses.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Profiles
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<Restaurant, RestaurantResponse>();
            CreateMap<CreateRestaurantCommand, Restaurant>();
            CreateMap<EditRestaurantCommand, Restaurant>()
                .ForMember(x => x.RestaurantId, opt => opt.Ignore());
        }
    }
}
