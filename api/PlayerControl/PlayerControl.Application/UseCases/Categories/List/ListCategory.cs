
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.List
{
    public class ListCategory : IListCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public ListCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyCollection<CategoryResponseModel>> Handle(ListCategoryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.List();

            return ListCategoryResponse.FromEntityList(categories);
        }
    }
}
