using PlayerControl.Domain.Entities.Categories;

namespace PlayerControl.Tests.Domain.CategoriesTest
{
    public class ValidationsTest
    {
        [Fact(DisplayName = nameof(WhenCategoryIsCreatedShouldBeActive))]
        public void WhenCategoryIsCreatedShouldBeActive()
        {
            // Arrange
            string name = "name";
            string description = "description";

            // Act
            var category = new Category(name, description);

            // Assert
            Assert.NotNull(category);
            Assert.True(category.IsActive);
        }

        [Fact(DisplayName = nameof(WhenCategoryIsDeactivateShouldHasIsActiveAsFalse))]
        public void WhenCategoryIsDeactivateShouldHasIsActiveAsFalse()
        {
            // Arrange
            string name = "name";
            string description = "description";

            // Act
            var category = new Category(name, description);
            category.Deactivate();

            // Assert
            Assert.NotNull(category);
            Assert.False(category.IsActive);
        }

        [Fact(DisplayName = nameof(WhenCategoryHasNullDescriptionShouldBeEmptyInstead))]
        public void WhenCategoryHasNullDescriptionShouldBeEmptyInstead()
        {
            // Arrange
            string name = "name";

            // Act
            var category = new Category(name, null!);
            category.Deactivate();

            // Assert
            Assert.Empty(category.Description);
            Assert.False(category.IsActive);
        }

        [Fact(DisplayName = nameof(WhenCategoryIsActivateShouldHasIsActiveAsTrue))]
        public void WhenCategoryIsActivateShouldHasIsActiveAsTrue()
        {
            // Arrange
            string name = "name";
            string description = "description";

            // Act
            var category = new Category(name, description);
            category.Deactivate();
            category.Activate();


            // Assert
            Assert.NotNull(category);
            Assert.True(category.IsActive);
        }
    }
}