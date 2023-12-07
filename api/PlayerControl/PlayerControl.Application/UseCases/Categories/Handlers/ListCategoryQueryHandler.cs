using PlayerControl.Application.UseCases.Categories.Interfaces;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Application.UseCases.Categories.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Handlers
{
    public class ListCategoryQueryHandler : IListCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public ListCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyCollection<CategoryResponseViewModel>> Handle(ListCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.List();

            return ListCategoryViewModel.FromEntityList(categories);
        }
    }
}
