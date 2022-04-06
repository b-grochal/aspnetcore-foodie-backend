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
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMealsById;
using Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants;
using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Categories
            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<Category, CreateCategoryCommandResponse>();

            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Category, UpdateCategoryCommandResponse>();

            CreateMap<Category, CategoryResponse>();

            CreateMap<Category, CategoryDetailsResponse>();

            // Cities
            CreateMap<CreateCityCommand, City>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<City, CreateCityCommandResponse>();

            CreateMap<UpdateCityCommand, City>();

            CreateMap<City, UpdateCityCommandResponse>();

            CreateMap<City, CityResponse>();

            CreateMap<City, CityDetailsResponse>();

            // Locations
            CreateMap<CreateLocationCommand, Location>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<Location, CreateLocationCommandResponse>();

            CreateMap<UpdateLocationCommand, Location>();

            CreateMap<Location, UpdateLocationCommandResponse>();

            CreateMap<Location, LocationResponse>();

            CreateMap<Location, LocationDetailsResponse>();

            CreateMap<Location, RestaurantLocationResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));

            // Meals
            CreateMap<CreateMealCommand, Meal>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<Meal, CreateMealCommandResponse>();

            CreateMap<UpdateMealCommand, Meal>();

            CreateMap<Meal, UpdateMealCommandResponse>();

            CreateMap<Meal, MealResponse>();

            CreateMap<Meal, MealDetailsResponse>();

            CreateMap<Meal, RestaurantMealResponse>();

            // Restaurants
            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.CreatedBy));

            CreateMap<Restaurant, CreateReastaurantCommandResponse>();

            CreateMap<UpdateRestaurantCommand, Restaurant>();

            CreateMap<Restaurant, UpdateReastaurantCommandResponse>();

            CreateMap<Restaurant, RestaurantResponse>();

            CreateMap<Restaurant, RestaurantDetailsResponse>();

        }
    }
}
