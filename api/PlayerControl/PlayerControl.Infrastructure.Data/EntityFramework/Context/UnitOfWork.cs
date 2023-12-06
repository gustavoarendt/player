using PlayerControl.Application.Interfaces;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityFrameworkDbContext _dbContext = null!;

        public UnitOfWork(EntityFrameworkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit() => _dbContext.SaveChangesAsync();

        public Task Rollback() => Task.CompletedTask;
    }
}
