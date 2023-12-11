using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerControl.Domain.Entities.Genres;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Genres.Mappings
{
    public class GenreCategoryMapping : IEntityTypeConfiguration<GenreCategory>
    {
        public void Configure(EntityTypeBuilder<GenreCategory> builder)
        {
            builder.ToTable("genre_category");
            builder.HasKey(relation => new { relation.GenreId, relation.CategoryId });

            builder.Property(gc => gc.GenreId).HasColumnName("id_genre");
            builder.Property(gc => gc.CategoryId).HasColumnName("id_category");
        }
    }
}
