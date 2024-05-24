using AutoMapper;
using Foodie.Meals.Application.Features.Categories.Commands.CreateCategory;
using Foodie.Meals.Application.Features.Categories.Commands.UpdateCategory;
using Foodie.Meals.Application.Features.Categories.Queries.GetCategories;
using Foodie.Meals.Application.Features.Categories.Queries.GetCategoryById;
using Foodie.Meals.Application.Functions.Cities.Commands.CreateCity;
using Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCities;
using Foodie.Meals.Application.Functions.Cities.Queries.GetCityById;
using Foodie.Meals.Application.Functions.Countries.Commands.CreateCountry;
using Foodie.Meals.Application.Functions.Countries.Commands.UpdateCountry;
using Foodie.Meals.Application.Functions.Countries.Queries.GetCountries;
using Foodie.Meals.Application.Functions.Countries.Queries.GetCountryById;
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
            ConfigureCategoriesMapping();
            ConfigureCitiesMapping();
            ConfiureLocationsMapping();
            ConfigureMealsMapping();
            ConfigureRestaurantsMapping();
            ConfigureCountriesMapping();
        }

        private void ConfigureCategoriesMapping()
        {
            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Category, CreateCategoryCommandResponse>();
            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Category, UpdateCategoryCommandResponse>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, GetCategoryByIdQueryResponse>();
        }

        private void ConfigureCitiesMapping()
        {
            CreateMap<CreateCityCommand, City>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<City, CreateCityCommandResponse>();
            CreateMap<UpdateCityCommand, City>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<City, UpdateCityCommandResponse>();
            CreateMap<City, CityDto>();
            CreateMap<City, GetCityByIdQueryResponse>();
        }

        private void ConfiureLocationsMapping()
        {
            CreateMap<CreateLocationCommand, Location>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Location, CreateLocationCommandResponse>();
            CreateMap<UpdateLocationCommand, Location>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
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
        }

        private void ConfigureMealsMapping()
        {
            CreateMap<CreateMealCommand, Meal>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Meal, CreateMealCommandResponse>();
            CreateMap<UpdateMealCommand, Meal>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Meal, UpdateMealCommandResponse>();
            CreateMap<Meal, MealDto>();
            CreateMap<Meal, GetMealByIdQueryResponse>();
            CreateMap<Meal, RestaurantMealDto>();
        }

        private void ConfigureRestaurantsMapping()
        {
            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Restaurant, CreateRestaurantCommandResponse>();
            CreateMap<UpdateRestaurantCommand, Restaurant>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Restaurant, UpdateRestaurantCommandResponse>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<Restaurant, GetRestaurantByIdQueryResponse>();
        }

        private void ConfigureCountriesMapping()
        {
            CreateMap<CreateCountryCommand, Country>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Country, CreateCountryCommandResponse>();
            CreateMap<UpdateCountryCommand, Country>()
                .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.ApplicationUserEmail));
            CreateMap<Country, UpdateCountryCommandResponse>();
            CreateMap<Country, CountryDto>();
            CreateMap<Country, GetCountryByIdQueryResponse>();
        }
    }
}
