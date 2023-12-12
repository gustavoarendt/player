using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Context
{
    public class EntityFrameworkDbContext : DbContext
    {
        public EntityFrameworkDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
