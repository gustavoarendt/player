using PlayerControl.Domain.Entities.Videos;

namespace PlayerControl.Domain.Validations
{
    public class VideoValidator : Validator
    {
        private readonly Video _video;
        private const int TitleMaxLength = 255;
        private const int TitleMinLength = 2;
        private const int DescriptionMaxLength = 2000;


        public VideoValidator(Video video, ValidationHandler handler) : base(handler)
        {
            _video = video;
        }

        public override void Validate()
        {
            ValidateTitle();
            ValidateDescription();
        }

        private void ValidateTitle()
        {
            if (_video.Title.Length > TitleMaxLength)
                _handler.HandleError($"{nameof(_video.Title)} should not exceed {TitleMaxLength} characters");
            if (_video.Title.Length < TitleMinLength)
                _handler.HandleError($"{nameof(_video.Title)} should has at least {TitleMinLength} characters");
        }

        private void ValidateDescription()
        {
            if (_video.Title.Length > DescriptionMaxLength)
                _handler.HandleError($"{nameof(_video.Title)} should not exceed {DescriptionMaxLength} characters");
        }
    }
}
