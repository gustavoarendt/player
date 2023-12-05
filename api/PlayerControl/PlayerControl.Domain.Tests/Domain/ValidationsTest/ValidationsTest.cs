using PlayerControl.Domain.Categories;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Tests.Domain.ValidationsTest
{
    public class ValidationsTest
    {
        [Fact(DisplayName = nameof(WhenStringIsNullOrWhitespaceShouldThrowException))]
        public void WhenStringIsNullOrWhitespaceShouldThrowException()
        {
            // Arrange
            var nameWithWhitespace = "  ";

            // Act
            void action() => DomainValidation.IsNullOrWhitespace(nameWithWhitespace, nameof(nameWithWhitespace));

            // Assert
            Assert.ThrowsAny<EntityValidationException>(action);
        }

        [Fact(DisplayName = nameof(WhenStringIsNotNullOrWhitespaceShouldNotThrowException))]
        public void WhenStringIsNotNullOrWhitespaceShouldNotThrowException()
        {
            // Arrange
            var category = new Category("name", "description");

            // Act
            DomainValidation.IsNullOrWhitespace(category.Name, nameof(category.Name));

            // Assert
            Assert.NotEmpty(category.Name);
        }

        [Fact(DisplayName = nameof(WhenStringDoesNotHasMinLengthShouldThrowException))]
        public void WhenStringDoesNotHasMinLengthShouldThrowException()
        {
            // Arrange
            var minLength = 3;
            var nameWithLessThanMinLength = "nm";

            // Act
            void action() => DomainValidation.MinLength(nameWithLessThanMinLength, minLength, nameof(nameWithLessThanMinLength));

            // Assert
            Assert.Throws<EntityValidationException>(action);
        }

        [Fact(DisplayName = nameof(WhenStringHasMoreThenMaxLengthShouldThrowException))]
        public void WhenStringHasMoreThenMaxLengthShouldThrowException()
        {
            // Arrange
            var maxLength = 19;
            var category = new Category("20_characters_length", "description");

            // Act
            void action() => DomainValidation.MaxLength(category.Name, maxLength, nameof(category.Name));

            // Assert
            Assert.Throws<EntityValidationException>(action);
        }
    }
}