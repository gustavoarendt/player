namespace PlayerControl.Domain.Validations
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string message): base(message) { }
    }
}
