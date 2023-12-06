using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerControl.Domain.Categories;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Categories.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("ID_CATEGORY").IsRequired();
            builder.Property(c => c.Name).HasColumnName("NAME").HasMaxLength(255).IsRequired();
            builder.Property(c => c.Description).HasColumnName("DESCRIPTION");
            builder.Property(c => c.IsActive).HasColumnName("IS_ACTIVE");
            builder.Property(c => c.CreatedAt).HasColumnName("CREATED_AT");
        }
    }
}
