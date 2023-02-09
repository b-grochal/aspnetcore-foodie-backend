using AutoMapper;
using Foodie.Meals.Application.Functions.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategories;
using Foodie.Meals.Application.Functions.Categories.Queries.GetCategoryById;
using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
using Foodie.Meals.Application.Functions.Locations.Commands.CreateLocation;
using Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById;
using Foodie.Meals.Application.Functions.Locations.Queries.GetLocations;
using Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal;
using Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMealById;
using Foodie.Meals.Application.Functions.Meals.Queries.GetMeals;
using Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
using Foodie.Meals.Domain.Entities;

namespace Foodie.Meals.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Categories
            CreateMap<CreateCategoryCommand, Category>();

            CreateMap<Category, CreateCategoryCommandResponse>();

            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Category, UpdateCategoryCommandResponse>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Category, GetCategoryByIdQueryResponse>();

            // Cities
            CreateMap<CreateCityCommand, City>();

            CreateMap<City, CreateCityCommandResponse>();

            CreateMap<UpdateCityCommand, City>();

            CreateMap<City, UpdateCityCommandResponse>();

            CreateMap<City, CityDto>();

            CreateMap<City, GetCityByIdQueryResponse>();

            // Locations
            CreateMap<CreateLocationCommand, Location>();

            CreateMap<Location, CreateLocationCommandResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));

            CreateMap<UpdateLocationCommand, Location>();

            CreateMap<Location, UpdateLocationCommandResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));

            CreateMap<Location, LocationDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));

            CreateMap<Location, GetLocationByIdQueryResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name));

            CreateMap<Location, RestaurantLocationDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));

            // Meals
            CreateMap<CreateMealCommand, Meal>();

            CreateMap<Meal, CreateMealCommandResponse>();

            CreateMap<UpdateMealCommand, Meal>();

            CreateMap<Meal, UpdateMealCommandResponse>();

            CreateMap<Meal, MealDto>();

            CreateMap<Meal, GetMealByIdQueryResponse>();

            CreateMap<Meal, RestaurantMealDto>();

            // Restaurants
            CreateMap<CreateRestaurantCommand, Restaurant>();

            CreateMap<Restaurant, CreateRestaurantCommandResponse>();

            CreateMap<UpdateRestaurantCommand, Restaurant>();

            CreateMap<Restaurant, UpdateRestaurantCommandResponse>();

            CreateMap<Restaurant, RestauranatDto>();

            CreateMap<Restaurant, GetRestaurantByIdQueryResponse>();

        }
    }
}
