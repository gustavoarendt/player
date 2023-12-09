namespace PlayerControl.Domain.Entities.Videos.ValueObjects
{
    public class Image
    {
        public string? Path { get; private set; }

        public Image(string path)
        {
            Path = path;
        }
    }
}
