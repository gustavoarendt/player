using PlayerControl.Application.UseCases.Videos.Interfaces;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Application.UseCases.Videos.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Videos.Handlers
{
    public class GetVideoQueryHandler : IGetVideo
    {
        private readonly IVideoRepository _videoRepository;

        public GetVideoQueryHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<VideoViewModel> Handle(GetVideoQuery request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetById(request.VideoId);

            return VideoViewModel.FromEntity(video);
        }
    }
}
