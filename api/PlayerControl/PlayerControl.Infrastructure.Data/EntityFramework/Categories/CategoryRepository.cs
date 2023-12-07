using Microsoft.EntityFrameworkCore;
using PlayerControl.Domain.Categories;
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

        public async Task<IEnumerable<Category>> List()
        {
            return await Task.FromResult(_categories.AsQueryable().AsNoTracking().Where(c => c.IsActive));
        }
    }
}
