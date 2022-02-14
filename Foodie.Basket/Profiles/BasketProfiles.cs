using AutoMapper;
using Foodie.Basket.Commands;
using Foodie.Basket.Models;
using Foodie.Basket.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Profiles
{
    public class BasketProfiles : Profile
    {
        public BasketProfiles()
        {
            CreateMap<CustomerBasket, CustomerBasketResponse>();
            CreateMap<BasketItem, BasketItemResponse>();
            CreateMap<UpdateBasketCommand, CustomerBasket>();
        }
    }
}
