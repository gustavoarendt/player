using Moq;
using PlayerControl.Application.Extensions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Videos.Commands;
using PlayerControl.Application.UseCases.Videos.Handlers;
using PlayerControl.Domain.Entities.Videos;
using PlayerControl.Domain.Entities.Videos.Enums;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Videos
{
    public class CreateVideoTest
    {
        [Fact(DisplayName = nameof(CreateVideo))]
        public async Task CreateVideo()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "Matrix";
            var description = "O jovem programador Thomas Anderson é atormentado por estranhos pesadelos em que está sempre conectado por cabos a um imenso sistema de computadores do futuro. À medida que o sonho se repete, ele começa a desconfiar da realidade.";
            var year = 1999;
            var duration = 136;
            var rating = Rating.R14;
            var repositoryMock = new Mock<IVideoRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var genreRepositoryMock = new Mock<IGenreRepository>();
            var storeServiceMock = new Mock<IStoreService>();
            var useCase = new CreateVideoCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object,
                categoryRepositoryMock.Object,
                genreRepositoryMock.Object,
                storeServiceMock.Object
            );
            var request = new CreateVideoCommand(id, title, description, year, duration, rating);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            repositoryMock.Verify((repository) => repository.Insert(It.IsAny<Video>()), Times.Once);
            unitOfWorkMock.Verify((unitOfWork) => unitOfWork.Commit(), Times.Once);
            Assert.NotNull(sut);
            Assert.Equal(title, sut.Title);
            Assert.Equal(description, sut.Description);
            Assert.Equal(year, sut.Year);
            Assert.Equal(duration, sut.Duration);
            Assert.Equal(rating.GetDescription(), sut.Rating);
            Assert.True(sut.Id != Guid.Empty);
            Assert.True(sut.CreatedAt != DateTime.MinValue);
        }
    }
}
