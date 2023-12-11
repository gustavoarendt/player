using Microsoft.Extensions.Logging;
using PlayerControl.Application.Interfaces;
using PlayerControl.Domain.Commons;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkDbContext _dbContext = null!;
        private readonly IDomainEventPublisher _publisher;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(
            EntityFrameworkDbContext dbContext,
            IDomainEventPublisher publisher,
            ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _publisher = publisher;
            _logger = logger;
        }

        public async Task Commit()
        {
            var entities = _dbContext.ChangeTracker
                .Entries<Entity>().Where(entry => entry.Entity.Events.Any()).Select(entry => entry.Entity);
            _logger.LogInformation($"{nameof(Commit)} - {entities.Count()} entities with events");

            var events = entities.SelectMany(entity => entity.Events);
            _logger.LogInformation($"{nameof(Commit)} - {events.Count()} events raised");

            foreach (var @event in events)
            {
                await _publisher.PublishEventAsync( @event );
            }

            await _dbContext.SaveChangesAsync();
        }

        public Task Rollback() => Task.CompletedTask;
    }
}
