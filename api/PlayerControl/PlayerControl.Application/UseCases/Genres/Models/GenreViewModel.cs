using PlayerControl.Domain.Genres;

namespace PlayerControl.Application.UseCases.Genres.Models
{
    public record GenreViewModel(Guid Id,  string Name, bool IsActive, DateTime CreatedAt, IReadOnlyList<Guid> CategoryIds)
    {
        public static GenreViewModel FromEntity(Genre genre)
        {
            return new GenreViewModel(genre.Id, genre.Name, genre.IsActive, genre.CreatedAt, genre.CategoryIds);
        }
    }
}
