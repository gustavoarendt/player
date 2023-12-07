using Moq;
using PlayerControl.Application.Exceptions;
using PlayerControl.Application.UseCases.Genres.Handlers;
using PlayerControl.Application.UseCases.Genres.Queries;
using PlayerControl.Domain.Genres;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Genres
{
    public class GetGenreTest
    {
        [Fact(DisplayName = nameof(GetGenre))]
        public async Task GetGenre()
        {
            // Arrange
            var repositoryMock = new Mock<IGenreRepository>();
            var genre = new Genre("name");
            var useCase = new GetGenreQueryHandler(
                repositoryMock.Object
            );
            var request = new GetGenreQuery(genre.Id);
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(genre);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(request.Id, sut.Id);
        }

        [Fact(DisplayName = nameof(WhenIdIsNotFoundShouldThrowNotFoundException))]
        public async Task WhenIdIsNotFoundShouldThrowNotFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<IGenreRepository>();
            var genre = new Genre("name");
            var useCase = new GetGenreQueryHandler(
                repositoryMock.Object
            );
            var request = new GetGenreQuery(genre.Id);
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ThrowsAsync(new NotFoundException($"{nameof(Genre)} of Id: {request.Id} could not be found"));

            // Act
            var sut = async () => await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Never);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(sut);
        }
    }
}
