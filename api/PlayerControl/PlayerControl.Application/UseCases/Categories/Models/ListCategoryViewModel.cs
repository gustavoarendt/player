using PlayerControl.Domain.Categories;

namespace PlayerControl.Application.UseCases.Categories.Models
{
    public record ListCategoryViewModel
    {
        public static IReadOnlyCollection<CategoryResponseViewModel> FromEntityList(IEnumerable<Category> categories)
        {
            var responseModels = categories.Select(category =>
            {
                return CategoryResponseViewModel.FromEntity(category);
            });

            return responseModels.ToList();
        }
    }
}
