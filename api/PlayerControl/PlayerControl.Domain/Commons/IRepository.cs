namespace PlayerControl.Domain.Commons
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public Task<TEntity> GetById(Guid id);
        public Task Insert(TEntity entity);
        public Task Update(TEntity entity);
        public Task Remove(TEntity entity);
    }
}
