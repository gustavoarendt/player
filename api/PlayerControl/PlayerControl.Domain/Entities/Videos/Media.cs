using PlayerControl.Domain.Entities.Videos.Enums;

namespace PlayerControl.Domain.Entities.Videos
{
    public class Media
    {
        public Media(string filePath)
        {
            FilePath = filePath;
            Status = Status.Pending;
        }

        public string FilePath { get; private set; } = string.Empty;
        public string EncodedPath { get; private set; } = string.Empty;
        public Status Status { get; private set; }

        public void AsEncoding() => Status = Status.Processing;
        public void AsEncoded(string encodedPath)
        {
            EncodedPath = encodedPath;
            Status = Status.Completed;
        }
    }
}
