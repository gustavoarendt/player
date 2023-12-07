using Microsoft.EntityFrameworkCore;
using PlayerControl.Application.Exceptions;
using PlayerControl.Domain.Commons;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Context
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly EntityFrameworkDbContext _context = null!;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(EntityFrameworkDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NotFoundException($"{nameof(Entity)} of Id: {id} could not be found");
            }

            return entity;
        }

        public virtual Task Insert(TEntity entity)
        {
            _dbSet.Add(entity);

            return Task.CompletedTask;
        }

        public virtual Task Remove(TEntity entity)
        {
            _dbSet.Remove(entity);

            return Task.CompletedTask;
        }

        public virtual Task Update(TEntity entity)
        {
            _dbSet.Update(entity);

            return Task.CompletedTask;
        }
    }
}
