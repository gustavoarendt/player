using PlayerControl.Domain.Commons;

namespace PlayerControl.Domain.Events
{
    public class VideoUploadedEvent : DomainEvent
    {
        public VideoUploadedEvent(Guid videoId, string filePath)
        {
            VideoId = videoId;
            this.filePath = filePath;
        }

        public Guid VideoId { get; private set; }
        public string filePath { get; private set; }
    }
}
