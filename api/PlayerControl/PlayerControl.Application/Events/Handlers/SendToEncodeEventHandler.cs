using PlayerControl.Application.Interfaces;
using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Events;

namespace PlayerControl.Application.Events.Handlers
{
    public class SendToEncodeEventHandler : IDomainEventHandler<VideoUploadedEvent>
    {
        private readonly IMessageProducer _messageProducer;

        public SendToEncodeEventHandler(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public async Task Handle(VideoUploadedEvent domainEvent)
        {
            await _messageProducer.SendMessageAsync(domainEvent);
        }
    }
}
