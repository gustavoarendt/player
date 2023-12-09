using MediatR;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Domain.Entities.Videos.Enums;

namespace PlayerControl.Application.UseCases.Videos.Commands
{
    public record CreateVideoCommand(Guid Id, string Title, string Description, int Year, int Duration, Rating Rating, IReadOnlyCollection<Guid>? CategoryIds = null, IReadOnlyCollection<Guid>? GenreIds = null, FileInputModel? Image = null, FileInputModel? Media = null) : IRequest<VideoViewModel>
    {
    }
}
