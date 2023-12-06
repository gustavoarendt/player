namespace PlayerControl.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public Task Commit();
        public Task Rollback();
    }
}
