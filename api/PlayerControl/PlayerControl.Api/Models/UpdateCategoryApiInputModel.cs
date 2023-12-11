namespace PlayerControl.Application.UseCases.Categories.Models
{
    public record UpdateCategoryApiInputModel(string? Name, string? Description, bool? IsActive)
    {
    }
}
