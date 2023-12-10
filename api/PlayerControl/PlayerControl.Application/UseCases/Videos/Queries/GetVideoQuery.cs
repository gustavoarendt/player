using MediatR;
using PlayerControl.Application.UseCases.Videos.Models;

namespace PlayerControl.Application.UseCases.Videos.Queries
{
    public record GetVideoQuery(Guid VideoId) : IRequest<VideoViewModel>
    {
    }
}
