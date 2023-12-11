using Microsoft.Extensions.DependencyInjection;
using PlayerControl.Domain.Commons;

namespace PlayerControl.Application.Events
{
    public class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent
        {
            var handlers = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();
            if (handlers is null || !handlers.Any()) return;
            foreach (var handler in handlers)
                await handler.Handle(domainEvent);
        }
    }
}
