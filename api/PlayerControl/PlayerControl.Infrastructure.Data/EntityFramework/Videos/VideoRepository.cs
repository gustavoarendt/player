using Microsoft.EntityFrameworkCore;
using PlayerControl.Application.Exceptions;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Videos;
using PlayerControl.Domain.Repositories;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Videos
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        readonly DbSet<Video> _videos;
        readonly DbSet<VideoGenres> _videosGenres;
        readonly DbSet<VideoCategories> _videosCategories;

        public VideoRepository(EntityFrameworkDbContext context) : base(context)
        {
            _videos = context.Set<Video>();
            _videosGenres = context.Set<VideoGenres>();
            _videosCategories = context.Set<VideoCategories>();
        }

        public override async Task<Video> GetById(Guid id)
        {
            var video = await _videos.FirstOrDefaultAsync(v => v.Id == id);
            if (video is null)
            {
                throw new NotFoundException($"{nameof(Entity)} of Id: {id} could not be found");
            }
            var videoGenresIds = await _videosGenres.Where(vg => vg.VideoId == id).Select(vg => vg.GenreId).ToListAsync();
            videoGenresIds.ForEach(video.AddGenre);
            var videoCategoryIds = await _videosCategories.Where(vc => vc.VideoId == id).Select(vc => vc.CategoryId).ToListAsync();
            videoCategoryIds.ForEach(video.AddCategory);

            return video;
        }

        public override async Task Insert(Video video)
        {
            await _videos.AddAsync(video);
            if (video.Genres is not null && video.Genres.Any())
            {
                var genreRelations = video.Genres.Select(genreId => new VideoGenres(video.Id, genreId));
                await _videosGenres.AddRangeAsync(genreRelations);
            }
            if (video.Categories is not null && video.Categories.Any())
            {
                var categoryRelations = video.Categories.Select(categoryId => new VideoCategories(video.Id, categoryId));
                await _videosCategories.AddRangeAsync(categoryRelations);
            }
        }

        public async Task<IEnumerable<Video>> List()
        {
            var videos = await _videos.ToListAsync();
            foreach (var video in videos)
            {
                var videoGenres = await _videosGenres.Where(vg => vg.VideoId == video.Id).Select(vg => vg.GenreId).ToListAsync();
                videoGenres.ForEach(video.AddGenre);
                var videoCategories = await _videosCategories.Where(vc => vc.VideoId == video.Id).Select(vc => vc.CategoryId).ToListAsync();
                videoCategories.ForEach(video.AddCategory);
            }
            return videos;
        }

        public override Task Remove(Video video)
        {
            _videosGenres.RemoveRange(_videosGenres.Where(vg => vg.VideoId == video.Id));
            _videosCategories.RemoveRange(_videosCategories.Where(vc => vc.VideoId == video.Id));
            _videos.Remove(video);
            return Task.CompletedTask;
        }

        public override async Task Update(Video video)
        {
            _videos.Update(video);
            _videosGenres.RemoveRange(_videosGenres.Where(vg => vg.VideoId == video.Id));
            _videosCategories.RemoveRange(_videosCategories.Where(vc => vc.VideoId == video.Id));
            if (video.Genres is not null && video.Genres.Any())
            {
                var genreRelations = video.Genres.Select(genreId => new VideoGenres(video.Id, genreId));
                await _videosGenres.AddRangeAsync(genreRelations);
            }
            if (video.Categories is not null && video.Categories.Any())
            {
                var categoryRelations = video.Categories.Select(categoryId => new VideoCategories(video.Id, categoryId));
                await _videosCategories.AddRangeAsync(categoryRelations);
            }
        }
    }
}
