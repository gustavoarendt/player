namespace PlayerControl.Domain.Commons
{
    public interface IDomainEventPublisher
    {
        Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;
    }
}
