using PlayerControl.Application.UseCases.Categories.Interfaces;
using PlayerControl.Application.UseCases.Categories.Models;
using PlayerControl.Application.UseCases.Categories.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Categories.Handlers
{
    public class GetCategoryQueryHandler : IGetCategory
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseViewModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);

            return CategoryResponseViewModel.FromEntity(category);
        }
    }
}
