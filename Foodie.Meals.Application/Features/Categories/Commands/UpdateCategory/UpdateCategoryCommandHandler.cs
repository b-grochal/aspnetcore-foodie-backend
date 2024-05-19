using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Categories.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<UpdateCategoryCommandResponse>>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoriesRepository categoriesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetByIdAsync(request.Id);

            if (category is null)
                return Result.Failure<UpdateCategoryCommandResponse>(CategoriesErrors.CategoryNotFoundById(request.Id));

            var editedCategory = _mapper.Map(request, category);
            await _categoriesRepository.UpdateAsync(editedCategory);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return _mapper.Map<UpdateCategoryCommandResponse>(editedCategory);
        }
    }
}
