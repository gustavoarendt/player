using PlayerControl.Domain.Entities.Videos;

namespace PlayerControl.Tests.Domain.VideoTest
{
    public class VideoTest
    {
        [Fact(DisplayName = nameof(Instanciate))]
        public void Instanciate()
        {
            // Arrange
            var title = "Matrix";
            var description = "O jovem programador Thomas Anderson é atormentado por estranhos pesadelos em que está sempre conectado por cabos a um imenso sistema de computadores do futuro. À medida que o sonho se repete, ele começa a desconfiar da realidade.";
            var year = 1999;
            var duration = 136;

            // Act
            var video = new Video(title, description, year, duration);

            // Assert
            Assert.Equal(title, video.Title);
            Assert.Equal(description, video.Description);
            Assert.Equal(year, video.Year);
            Assert.Equal(duration, video.Duration);
            Assert.True(video.Id != Guid.Empty);
            Assert.True(video.CreatedAt != DateTime.MinValue);
        }
    }
}
