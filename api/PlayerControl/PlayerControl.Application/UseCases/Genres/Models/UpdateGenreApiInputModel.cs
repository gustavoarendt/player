namespace PlayerControl.Application.UseCases.Genres.Models
{
    public record UpdateGenreApiInputModel(string? Name, bool? IsActive, List<Guid>? CategoryIds)
    {
    }
}
