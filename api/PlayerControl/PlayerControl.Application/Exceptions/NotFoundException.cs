namespace PlayerControl.Application.Exceptions
{
    public class NotFoundException : ApplicationValidationException
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
