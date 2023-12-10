using PlayerControl.Application.UseCases.Videos.Interfaces;
using PlayerControl.Application.UseCases.Videos.Models;
using PlayerControl.Application.UseCases.Videos.Queries;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Application.UseCases.Videos.Handlers
{
    public class ListVideoQueryHandler : IListVideo
    {
        private readonly IVideoRepository _videoRepository;

        public ListVideoQueryHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<IReadOnlyCollection<VideoViewModel>> Handle(ListVideoQuery request, CancellationToken cancellationToken)
        {
            var videos = await _videoRepository.List();

            return videos.Select(VideoViewModel.FromEntity).ToList();
        }
    }
}
