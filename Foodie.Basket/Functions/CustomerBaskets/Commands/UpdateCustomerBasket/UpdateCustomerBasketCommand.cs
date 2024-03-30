﻿using Foodie.Basket.API.Dtos;
using Foodie.Common.Application.Requests.Abstractions;
using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket
{
    public class UpdateCustomerBasketCommand : IRequest<UpdateCustomerBasketCommandResponse>, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public int LocationId { get; set; }
        public IReadOnlyCollection<CustomerBasketItemDto> Items { get; set; }
    }
}
