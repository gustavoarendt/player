using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Domain.Categories;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Create
{
    public class CreateCategory : ICreateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponseModel> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name, request.Description);

            await _categoryRepository.Insert(category);
            await _unitOfWork.Commit();

            return CategoryResponseModel.FromEntity(category);
        }
    }
}
