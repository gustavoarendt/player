using PlayerControl.Domain.Entities.Categories;

namespace PlayerControl.Domain.Entities.Videos
{
    public class VideoCategories
    {
        public VideoCategories(Guid videoId, Guid categoryId)
        {
            VideoId = videoId;
            CategoryId = categoryId;
        }

        public Guid VideoId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Video? Video { get; private set; }
        public Category? Category { get; private set; }
    }
}
