using MediatR;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Application.UseCases.Videos.Queries;

namespace PlayerControl.Application.UseCases.Videos.Interfaces
{
    public interface IListVideo : IRequestHandler<ListVideoQuery, IReadOnlyCollection<VideoViewModel>>
    {
    }
}
