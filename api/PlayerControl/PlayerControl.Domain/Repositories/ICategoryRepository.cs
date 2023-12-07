using PlayerControl.Domain.Categories;
using PlayerControl.Domain.Commons;

namespace PlayerControl.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<IEnumerable<Category>> List();
        public Task<IEnumerable<Guid>> GetIdListByIds();
    }
}
