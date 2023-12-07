namespace PlayerControl.Application.UseCases.Categories.Update
{
    public record UpdateCategoryApiRequest(string? Name, string? Description, bool? IsActive)
    {
    }
}
