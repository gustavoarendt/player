using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Videos.Enums;
using PlayerControl.Domain.Entities.Videos.ValueObjects;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Domain.Entities.Videos
{
    public class Video : Entity
    {
        public Video(string title, string description, int year, int duration, Rating rating) : base()
        {
            Title = title;
            Description = description;
            Year = year;
            Duration = duration;
            Rating = rating;
            _categories = new();
            _genres = new();
        }

        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Year { get; private set; }
        public int Duration { get; private set; }
        public Rating Rating { get; private set; }
        public Image? Image { get; private set; }
        public Media? Media { get; private set; }
        private List<Guid> _categories;
        public IReadOnlyList<Guid> Categories => _categories.AsReadOnly();
        private List<Guid> _genres;
        public IReadOnlyList<Guid> Genres => _genres.AsReadOnly();


        public void AddVideo(Image video) => Image = video;
        public void AddMedia(Media media) => Media = media;
        public void AddCategory(Guid CategoryId) => _categories.Add(CategoryId);
        public void RemoveCategory(Guid CategoryId) => _categories.Remove(CategoryId);
        public void RemoveAllCategory() => _categories.Clear();
        public void AddGenre(Guid GenreId) => _genres.Add(GenreId);
        public void RemoveGenre(Guid GenreId) => _genres.Remove(GenreId);
        public void RemoveAllGenre() => _genres.Clear();

        public void SentToEncoding()
        {
            if (Media is null) throw new EntityValidationException("No media found");
            Media.AsEncoding();
        }

        public void SentEncodeed(string encodedPath)
        {
            if (Media is null) throw new EntityValidationException("No media found");
            Media.AsEncoded(encodedPath);
        }

        public void Validate(ValidationHandler handler)
        {
            new VideoValidator(this, handler).Validate();
        }

        public void UpdateImage(string imagePath)
        {
            Image = new Image(imagePath);
        }

        public void UpdateMedia(string videoPath)
        {
            Media = new Media(videoPath);
        }
    }
}
