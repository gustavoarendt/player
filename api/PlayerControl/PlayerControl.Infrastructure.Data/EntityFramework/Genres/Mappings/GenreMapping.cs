using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerControl.Domain.Genres;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Genres.Mappings
{
    internal class GenreMapping : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.ToTable("genre");

            builder.Property(g => g.Id).HasColumnName("id_genre").IsRequired();
            builder.Property(g => g.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
            builder.Property(g => g.IsActive).HasColumnName("is_active");
            builder.Property(g => g.CreatedAt).HasColumnName("created_at");

            builder
                .HasMany(g => g.GenreCategories)
                .WithOne(gc => gc.Genre)
                .HasForeignKey(gc => gc.GenreId);
        }
    }
}
