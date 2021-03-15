using AutoMapper;
using Foodie.Meals.Commands.Meals;
using Foodie.Meals.Models;
using Foodie.Meals.Responses.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Profiles
{
    public class MealsProfile : Profile
    {
        public MealsProfile()
        {
            CreateMap<Meal, MealResponse>();
            CreateMap<CreateMealCommand, Meal>();
            CreateMap<EditMealCommand, Meal>()
                .ForMember(x => x.MealId, opt => opt.Ignore());
        }
    }
}
