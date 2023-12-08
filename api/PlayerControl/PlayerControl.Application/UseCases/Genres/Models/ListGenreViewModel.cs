using PlayerControl.Domain.Entities.Genres;

namespace PlayerControl.Application.UseCases.Genres.Models
{
    internal class ListGenreViewModel
    {
        public static IReadOnlyCollection<GenreViewModel> FromEntityList(IEnumerable<Genre> genres)
        {
            var responseModels = genres.Select(genre =>
            {
                return GenreViewModel.FromEntity(genre);
            });

            return responseModels.ToList();
        }
    }
}
