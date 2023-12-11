namespace PlayerControl.Domain.Commons
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : DomainEvent
    {
        Task Handle(TDomainEvent domainEvent);
    }
}
