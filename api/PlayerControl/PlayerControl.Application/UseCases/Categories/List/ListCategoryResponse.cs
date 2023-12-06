using PlayerControl.Application.UseCases.Categories.Common;
using PlayerControl.Domain.Categories;

namespace PlayerControl.Application.UseCases.Categories.List
{
    public record ListCategoryResponse
    {
        public static IReadOnlyCollection<CategoryResponseModel> FromEntityList(IEnumerable<Category> categories)
        {
            var responseModels = categories.Select(category =>
            {
                return CategoryResponseModel.FromEntity(category);
            });

            return responseModels.ToList();
        }
    }
}
