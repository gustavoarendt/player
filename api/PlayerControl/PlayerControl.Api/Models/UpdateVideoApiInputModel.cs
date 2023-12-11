using PlayerControl.Domain.Entities.Videos.Enums;

namespace PlayerControl.Application.UseCases.Videos.Models
{
    public record UpdateVideoApiInputModel(string Title, string Description, int Year, int Duration, Rating Rating, IReadOnlyCollection<Guid>? CategoryIds = null, IReadOnlyCollection<Guid>? GenreIds = null, FileInputModel? Image = null, FileInputModel? Media = null)
    {
    }
}
