using Moq;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Genres.Commands;
using PlayerControl.Application.UseCases.Genres.Handlers;
using PlayerControl.Domain.Entities.Genres;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Genres
{
    public class CreateGenreTest
    {
        [Fact(DisplayName = nameof(CreateGenre))]
        public async Task CreateGenre()
        {
            // Arrange
            var genreName = "name";
            var repositoryMock = new Mock<IGenreRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var useCase = new CreateGenreCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object,
                categoryRepositoryMock.Object
            );
            var request = new CreateGenreCommand(genreName);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.Insert(It.IsAny<Genre>()), Times.Once);
            unitOfWorkMock.Verify((unitOfWork) => unitOfWork.Commit(), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.True(sut.IsActive);
            Assert.Equal(genreName, sut.Name);
            Assert.True(sut.Id != Guid.Empty);
            Assert.True(sut.CreatedAt != DateTime.MinValue);
        }
    }
}
