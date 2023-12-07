using Moq;
using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Handlers;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Genres;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Genres
{
    public class UpdateGenreTest
    {
        [Fact(DisplayName = nameof(UpdateGenre))]
        public async Task UpdateGenre()
        {
            // Arrange
            var repositoryMock = new Mock<IGenreRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var useCase = new UpdateGenreCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object,
                categoryRepositoryMock.Object
            );
            var genre = new Genre("name");
            var request = new UpdateGenreCommand(genre.Id, "name2", null, null);
            repositoryMock.Setup(x => x.GetById(request.Id)).ReturnsAsync(genre);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Once);
            repositoryMock.Verify((repository) => repository.Update(It.IsAny<Genre>()), Times.Once);
            unitOfWorkMock.Verify((unitOfWork) => unitOfWork.Commit(), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.True(sut.Name.Equals(request.Name));
            Assert.False(sut.IsActive.Equals(request.IsActive));
            Assert.True(sut.IsActive);
        }

        [Fact(DisplayName = nameof(WhenGenreToUpdateCannotBeFoundShouldThrowNotFoundException))]
        public async Task WhenGenreToUpdateCannotBeFoundShouldThrowNotFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<IGenreRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new DeleteGenreCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object
            );
            var request = new DeleteGenreCommand(Guid.NewGuid());
            repositoryMock.Setup(x => x.GetById(request.Id)).ThrowsAsync(new NotFoundException($"{nameof(Entity)} of Id: {request.Id} could not be found"));


            // Act
            var sut = async () => await useCase.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(sut);
        }
    }
}
