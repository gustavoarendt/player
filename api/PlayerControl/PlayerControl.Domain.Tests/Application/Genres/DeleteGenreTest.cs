using Moq;
using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Handlers;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Genres;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Genres
{
    public class DeleteGenreTest
    {
        [Fact(DisplayName = nameof(DeleteGenre))]
        public async Task DeleteGenre()
        {
            // Arrange
            var repositoryMock = new Mock<IGenreRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new DeleteGenreCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object
            );
            var genre = new Genre("name");
            var request = new DeleteGenreCommand(Guid.NewGuid());
            repositoryMock.Setup(x => x.GetById(request.Id)).ReturnsAsync(genre);

            // Act
            await useCase.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Once);
            repositoryMock.Verify((repository) => repository.Remove(It.IsAny<Genre>()), Times.Once);
            unitOfWorkMock.Verify((unitOfWork) => unitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = nameof(WhenGenreToDeleteCannotBeFoundShouldThrowNotFoundException))]
        public async Task WhenGenreToDeleteCannotBeFoundShouldThrowNotFoundException()
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
