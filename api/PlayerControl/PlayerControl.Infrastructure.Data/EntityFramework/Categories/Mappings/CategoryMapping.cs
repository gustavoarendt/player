using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerControl.Domain.Entities.Categories;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Categories.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("category");

            builder.Property(c => c.Id).HasColumnName("id_category").IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
            builder.Property(c => c.Description).HasColumnName("description");
            builder.Property(c => c.IsActive).HasColumnName("is_active");
            builder.Property(c => c.CreatedAt).HasColumnName("created_at");
        }
    }
}
