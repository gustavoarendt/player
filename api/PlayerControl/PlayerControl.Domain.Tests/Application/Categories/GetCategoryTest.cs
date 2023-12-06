using Moq;
using PlayerControl.Application.UseCases.Categories.Get;
using PlayerControl.Domain.Categories;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Categories
{
    public class GetCategoryTest
    {
        [Fact(DisplayName = nameof(GetCategory))]
        public async Task GetCategory()
        {
            // Arrange
            var repositoryMock = new Mock<ICategoryRepository>();
            var category = new Category("name", "description");
            var useCase = new GetCategory(
                repositoryMock.Object
            );
            var request = new GetCategoryRequest(category.Id);
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(category);

            // Act
            var sut = await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Once);

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(request.Id, sut.Id);
        }
    }
}
