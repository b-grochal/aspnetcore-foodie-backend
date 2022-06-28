using AutoMapper;
using Foodie.Meals.Domain.Entities;

namespace Foodie.Meals.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Location, MealsGrpc.Location>()
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.CityCountry, opt => opt.MapFrom(src => src.City.Country));
        }
    }
}
