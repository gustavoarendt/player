using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerControl.Domain.Commons
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        private readonly List<DomainEvent> _events = new();
        public IReadOnlyCollection<DomainEvent> Events => new ReadOnlyCollection<DomainEvent>(_events);

        public void RaiseEvent(DomainEvent e) => _events.Add(e);
        public void ClearEvents() => _events.Clear();
    }
}
