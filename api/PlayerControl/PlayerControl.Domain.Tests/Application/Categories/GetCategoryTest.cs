﻿using Moq;
using PlayerControl.Application.Exceptions;
using PlayerControl.Application.UseCases.Categories.Handlers;
using PlayerControl.Application.UseCases.Categories.Queries;
using PlayerControl.Domain.Entities.Categories;
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
            var useCase = new GetCategoryQueryHandler(
                repositoryMock.Object
            );
            var request = new GetCategoryQuery(category.Id);
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ReturnsAsync(category);

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
            var repositoryMock = new Mock<ICategoryRepository>();
            var category = new Category("name", "description");
            var useCase = new GetCategoryQueryHandler(
                repositoryMock.Object
            );
            var request = new GetCategoryQuery(category.Id);
            repositoryMock.Setup(mock => mock.GetById(It.IsAny<Guid>())).ThrowsAsync(new NotFoundException($"{nameof(Category)} of Id: {request.Id} could not be found"));

            // Act
            var sut = async () => await useCase.Handle(request, It.IsAny<CancellationToken>());
            repositoryMock.Verify((repository) => repository.GetById(It.IsAny<Guid>()), Times.Never);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(sut);
        }
    }
}
