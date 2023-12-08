using PlayerControl.Domain.Entities.Categories;

namespace PlayerControl.Application.UseCases.Categories.Models
{
    public record CategoryResponseViewModel(Guid Id, string Name, string Description, bool IsActive, DateTime CreatedAt)
    {
        public static CategoryResponseViewModel FromEntity(Category category)
        {
            return new CategoryResponseViewModel(category.Id, category.Name, category.Description, category.IsActive, category.CreatedAt);
        }
    }
}
