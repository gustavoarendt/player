using MediatR;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Models;

namespace PlayerControl.Application.UseCases.Videos.Interfaces
{
    public interface ICreateVideo : IRequestHandler<CreateVideoCommand, VideoViewModel>
    {
    }
}
