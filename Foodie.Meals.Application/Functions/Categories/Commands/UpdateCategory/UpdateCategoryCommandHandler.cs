using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
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

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetByIdAsync(request.Id);

            if (category == null)
                throw new CategoryNotFoundException(request.Id);

            var editedCategory = _mapper.Map(request, category);
            await _categoriesRepository.UpdateAsync(editedCategory);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateCategoryCommandResponse>(editedCategory);
        }
    }
}
