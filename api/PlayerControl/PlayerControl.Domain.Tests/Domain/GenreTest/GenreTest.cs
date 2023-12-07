using PlayerControl.Domain.Genres;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Tests.Domain.GenreTest
{
    public class GenreTest
    {
        [Fact(DisplayName = nameof(Instanciate))]
        public void Instanciate()
        {
            // Arrange
            var name = "Comedy";

            // Act
            var genre = new Genre(name);

            // Assert
            Assert.NotNull(genre);
            Assert.Equal(name, genre.Name);
            Assert.True(genre.IsActive);
            Assert.True(genre.Id != Guid.Empty);
            Assert.True(genre.CreatedAt != DateTime.MinValue);
        }

        [Fact(DisplayName = nameof(Instanciate))]
        public void WhenNameIsNullOrWhitespaceoShouldThrowEntityValidationException()
        {
            // Arrange
            var name = "";

            // Act
            var genre = () => new Genre(name);

            // Assert
            Assert.Throws<EntityValidationException>(genre);
        }

        [Fact(DisplayName = nameof(AddCategoryIds))]
        public void AddCategoryIds()
        {
            // Arrange
            var drama = Guid.NewGuid();
            var comedy = Guid.NewGuid();
            var action = Guid.NewGuid();
            var genre = new Genre("Thriller");

            // Act
            genre.AddCategoryId(drama);
            genre.AddCategoryId(comedy);
            genre.AddCategoryId(action);
            genre.RemoveCategoryId(action);

            // Assert
            Assert.NotNull(genre);
            Assert.Equal(2, genre.CategoryIds.Count);
        }
    }
}
