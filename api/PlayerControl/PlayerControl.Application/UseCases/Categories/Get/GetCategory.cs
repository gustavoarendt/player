
using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Get
{
    public class GetCategory : IGetCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseModel> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);

            return CategoryResponseModel.FromEntity(category);
        }
    }
}
