using Moq;
using PlayerControl.Application.UseCases.Genres.Handlers;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Genres;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Genres
{
    public class ListGenreTest
    {
        [Fact(DisplayName = nameof(ListGenre))]
        public async Task ListGenre()
        {
            // Arrange
            var repositoryMock = new Mock<IGenreRepository>();
            var genreOne = new Genre("name");
            var genreTwo = new Genre("name2");
            var categories = new List<Genre>() { genreOne, genreTwo };
            var useCase = new ListGenreQueryHandler(
                repositoryMock.Object
            );
            var request = new ListGenreQuery();
            repositoryMock.Setup(mock => mock.List()).ReturnsAsync(categories);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.List(), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(2, sut.Count);
        }
    }
}
