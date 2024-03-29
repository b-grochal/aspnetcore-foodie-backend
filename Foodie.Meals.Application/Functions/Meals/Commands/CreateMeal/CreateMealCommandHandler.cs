﻿using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, CreateMealCommandResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public CreateMealCommandHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<CreateMealCommandResponse> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = mapper.Map<Meal>(request);
            await mealsRepository.CreateAsync(meal);
            return mapper.Map<CreateMealCommandResponse>(meal);
        }
    }
}
