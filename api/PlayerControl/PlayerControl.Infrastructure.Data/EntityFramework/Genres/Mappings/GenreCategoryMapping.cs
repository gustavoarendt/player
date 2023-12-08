using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerControl.Domain.Entities.Genres;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Genres.Mappings
{
    public class GenreCategoryMapping : IEntityTypeConfiguration<GenreCategory>
    {
        public void Configure(EntityTypeBuilder<GenreCategory> builder)
        {
            builder.HasKey(gc => gc.Id);
            builder.ToTable("genre_category");

            builder.Property(gc => gc.Id).HasColumnName("id_genre_category").IsRequired();
            builder.Property(gc => gc.CategoryId).HasColumnName("id_category").IsRequired();
            builder.Property(gc => gc.GenreId).HasColumnName("id_genre").IsRequired();
            builder.Property(gc => gc.CreatedAt).HasColumnName("created_at");
        }
    }
}
