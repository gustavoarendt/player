using PlayerControl.Domain.Entities.Genres;

namespace PlayerControl.Domain.Entities.Videos
{
    public class VideoGenres
    {
        public VideoGenres(Guid videoId, Guid genreId)
        {
            VideoId = videoId;
            GenreId = genreId;
        }

        public Guid VideoId { get; private set; }
        public Guid GenreId { get; private set; }
        public Video? Video { get; private set; }
        public Genre? Genre { get; private set; }
    }
}
