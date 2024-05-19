using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Meals.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMealById
{
    public class GetMealByIdQueryHandler : IRequestHandler<GetMealByIdQuery, Result<GetMealByIdQueryResponse>>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealByIdQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetMealByIdQueryResponse>> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetByIdAsync(request.Id);

            if (meal is null)
                return Result.Failure<GetMealByIdQueryResponse>(MealsErrors.MealNotFoundById(request.Id));

            return mapper.Map<GetMealByIdQueryResponse>(meal);
        }
    }
}
