using PlayerControl.Domain.Entities.Genres;

namespace PlayerControl.Application.UseCases.Genres.Models
{
    public record GenreCategoryViewModel(Guid Id,  string Name)
    {
        public static IEnumerable<GenreCategoryViewModel> FromGenre(Genre genre)
        {
            var result = genre.GenreCategories.Select(gc =>
            {
                return new GenreCategoryViewModel(gc.CategoryId, gc.Category?.Name);
            });
            return result;
        }
    }
}