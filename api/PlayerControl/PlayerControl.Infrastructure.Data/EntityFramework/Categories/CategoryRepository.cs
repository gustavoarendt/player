using Microsoft.EntityFrameworkCore;
using PlayerControl.Domain.Entities.Categories;
using PlayerControl.Domain.Repositories;
using PlayerControl.Infrastructure.Data.EntityFramework.Context;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Categories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        readonly DbSet<Category> _categories;

        public CategoryRepository(EntityFrameworkDbContext context) : base(context)
        {

            _categories = context.Set<Category>();
        }

        public async Task<IEnumerable<Guid>> GetIdListByIds(ICollection<Guid> ids)
        {
            return await Task.FromResult(_categories.AsQueryable().AsNoTracking().Where(c => ids.Contains(c.Id)).Select(x => x.Id));
        }

        public async Task<IEnumerable<Category>> List()
        {
            return await Task.FromResult(_categories.AsQueryable().AsNoTracking().Where(c => c.IsActive));
        }
    }
}
