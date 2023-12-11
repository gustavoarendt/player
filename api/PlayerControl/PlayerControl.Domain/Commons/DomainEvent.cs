namespace PlayerControl.Domain.Commons
{
    public class DomainEvent
    {
        public DateTime OccuredAt { get; set; }
        protected DomainEvent()
        {
            OccuredAt = DateTime.UtcNow;
        }
    }
}
