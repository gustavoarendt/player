using Microsoft.Extensions.Options;
using PlayerControl.Application.Interfaces;
using RabbitMQ.Client;
using System.Text.Json;

namespace PlayerControl.Infrastructure.Messaging.Producer
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IModel _channel;
        private readonly string _exchange;

        public RabbitMQProducer(IModel channel, IOptions<RabbitMQSettings> options)
        {
            _channel = channel;
            _exchange = options.Value.Exchange;
        }

        public Task SendMessageAsync<T>(T message)
        {
            var routingKey = EventMapping.GetRoutingKey<T>();
            var @event = JsonSerializer.SerializeToUtf8Bytes(message);
            _channel.BasicPublish(
                exchange: _exchange,
                routingKey: routingKey,
                body: @event);
            _channel.WaitForConfirmsOrDie();
            return Task.CompletedTask;
        }
    }
}
