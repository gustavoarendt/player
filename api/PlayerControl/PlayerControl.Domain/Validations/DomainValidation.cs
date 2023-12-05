namespace PlayerControl.Domain.Validations
{
    public static class DomainValidation
    {
        public static void IsNullOrWhitespace(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EntityValidationException($"{fieldName} should not be null or empty");
            }
        }

        public static void MinLength(string value, int minLength, string fieldName)
        {
            if (value.Length < minLength)
            {
                throw new EntityValidationException($"{fieldName} should have at least {minLength} characters");
            }
        }

        public static void MaxLength(string value, int maxLength, string fieldName)
        {
            if (value.Length > maxLength)
            {
                throw new EntityValidationException($"{fieldName} should have less or equal then {maxLength} characters");
            }
        }
    }
}
