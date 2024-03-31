using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMealById
{
    public class GetMealByIdQueryHandler : IRequestHandler<GetMealByIdQuery, GetMealByIdQueryResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealByIdQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<GetMealByIdQueryResponse> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetByIdAsync(request.Id);

            if (meal == null)
                throw new MealNotFoundException(request.Id);

            return mapper.Map<GetMealByIdQueryResponse>(meal);
        }
    }
}
