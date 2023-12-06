using Moq;
using PlayerControl.Application.UseCases.Categories.List;
using PlayerControl.Domain.Categories;
using PlayerControl.Domain.Repositories;

namespace PlayerControl.Tests.Application.Categories
{
    public class ListCategoryTest
    {
        [Fact(DisplayName = nameof(ListCategory))]
        public async Task ListCategory()
        {
            // Arrange
            var repositoryMock = new Mock<ICategoryRepository>();
            var categoryOne = new Category("name", "description");
            var categoryTwo = new Category("name2", "description2");
            var categories = new List<Category>() { categoryOne, categoryTwo };
            var useCase = new ListCategory(
                repositoryMock.Object
            );
            var request = new ListCategoryRequest();
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
