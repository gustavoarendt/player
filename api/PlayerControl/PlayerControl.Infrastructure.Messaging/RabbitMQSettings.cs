namespace PlayerControl.Infrastructure.Messaging
{
    public class RabbitMQSettings
    {
        public const string AppSettings = "RabbitMQ";
        public string Hostname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
    }
}
