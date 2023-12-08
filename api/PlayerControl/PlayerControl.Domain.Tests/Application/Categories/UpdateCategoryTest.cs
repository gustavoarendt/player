using Moq;
using PlayerControl.Application.Exceptions;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Commands;
using PlayerControl.Application.UseCases.Categories.Handlers;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Categories;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Categories
{
    public class UpdateGenreTest
    {
        [Fact(DisplayName = nameof(UpdateCategory))]
        public async Task UpdateCategory()
        {
            // Arrange
            var repositoryMock = new Mock<ICategoryRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new UpdateCategoryCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object
            );
            var category = new Category("name", "description");
            var request = new UpdateCategoryCommand(category.Id, "name2", null, null);
            repositoryMock.Setup(x => x.GetById(request.Id)).ReturnsAsync(category);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Once);
            repositoryMock.Verify((repository) => repository.Update(It.IsAny<Category>()), Times.Once);
            unitOfWorkMock.Verify((unitOfWork) => unitOfWork.Commit(), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.True(sut.Name.Equals(request.Name));
            Assert.False(sut.Description.Equals(request.Description));
            Assert.True(sut.Description.Equals(category.Description));
            Assert.False(sut.IsActive.Equals(request.IsActive));
            Assert.True(sut.IsActive);
        }

        [Fact(DisplayName = nameof(WhenCategoryToUpdateCannotBeFoundShouldThrowNotFoundException))]
        public async Task WhenCategoryToUpdateCannotBeFoundShouldThrowNotFoundException()
        {
            // Arrange
            var repositoryMock = new Mock<ICategoryRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new DeleteCategoryCommandHandler(
                repositoryMock.Object,
                unitOfWorkMock.Object
            );
            var request = new DeleteCategoryCommand(Guid.NewGuid());
            repositoryMock.Setup(x => x.GetById(request.Id)).ThrowsAsync(new NotFoundException($"{nameof(Entity)} of Id: {request.Id} could not be found"));


            // Act
            var sut = async () => await useCase.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(sut);
        }
    }
}
