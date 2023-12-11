using PlayerControl.Domain.Events;

namespace PlayerControl.Infrastructure.Messaging
{
    public class EventMapping
    {
        private static Dictionary<string, string> _routingKeys = new()
        {
            { typeof(VideoUploadedEvent).Name, "video.created" }
        };

        public static string GetRoutingKey<T>() => _routingKeys[typeof(T).Name];
    }
}
