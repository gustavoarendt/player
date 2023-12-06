using Moq;
using PlayerControl.Application.Interfaces;
using PlayerControl.Application.UseCases.Categories.Create;
using PlayerControl.Domain.Categories;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Categories
{
    public class CreateCategoryTest
    {
        [Fact(DisplayName = nameof(CreateCategory))]
        public async Task CreateCategory()
        {
            // Arrange
            var categoryName = "name";
            var categoryDescription = "description";
            var repositoryMock = new Mock<ICategoryRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var useCase = new CreateCategory(
                repositoryMock.Object,
                unitOfWorkMock.Object
            );
            var request = new CreateCategoryRequest(categoryName, categoryDescription);
            
            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.Insert(It.IsAny<Category>()), Times.Once);
            unitOfWorkMock.Verify((unitOfWork) => unitOfWork.Commit(), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.True(sut.IsActive);
            Assert.Equal(categoryName, sut.Name);
            Assert.Equal(categoryDescription, sut.Description);
            Assert.True(sut.Id != Guid.Empty);
            Assert.True(sut.CreatedAt != DateTime.MinValue);
        }
    }
}
