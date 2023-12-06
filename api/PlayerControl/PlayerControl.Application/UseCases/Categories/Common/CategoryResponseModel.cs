using PlayerControl.Domain.Categories;

namespace PlayerControl.Application.UseCases.Categories.Common
{
    public record CategoryResponseModel(Guid Id, string Name, string Description, bool IsActive, DateTime CreatedAt)
    {
        public static CategoryResponseModel FromEntity(Category category)
        {
            return new CategoryResponseModel(category.Id, category.Name, category.Description, category.IsActive, category.CreatedAt);
        }
    }
}
