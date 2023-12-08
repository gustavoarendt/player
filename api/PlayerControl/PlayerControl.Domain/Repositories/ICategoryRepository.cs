using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Categories;

namespace PlayerControl.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<IEnumerable<Category>> List();
        public Task<IEnumerable<Guid>> GetIdListByIds();
    }
}
