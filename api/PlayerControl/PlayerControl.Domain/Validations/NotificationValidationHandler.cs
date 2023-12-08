namespace PlayerControl.Domain.Validations
{
    public class NotificationValidationHandler : ValidationHandler
    {
        private readonly List<ValidationError> _errors;
        public IReadOnlyCollection<ValidationError> Errors { get { return _errors; } }

        public NotificationValidationHandler()
        {
            _errors = new List<ValidationError>();
        }

        public bool HasErrors() => _errors.Count > 0;

        public override void HandleError(ValidationError error)
        {
            _errors.Add(error);
        }
    }
}
