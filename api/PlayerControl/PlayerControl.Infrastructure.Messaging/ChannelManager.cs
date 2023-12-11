using RabbitMQ.Client;

namespace PlayerControl.Infrastructure.Messaging
{
    public class ChannelManager
    {
        private readonly IConnection _connection;
        private readonly object _lock = new object();
        private IModel? _channel = null;

        public ChannelManager(IConnection connection)
        {
            _connection = connection;
        }

        public IModel GetChannel()
        {
            lock (_lock)
            {
                if (_channel is null || _channel.IsClosed)
                {
                    _channel = _connection.CreateModel();
                }
                return _channel;
            }
        }
    }
}
