using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayerControl.Domain.Entities.Videos;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Videos.Mappings
{
    public class VideoGenresMapping : IEntityTypeConfiguration<VideoGenres>
    {
        public void Configure(EntityTypeBuilder<VideoGenres> builder)
        {
            builder.ToTable("video_genre");
            builder.HasKey(relation => new { relation.VideoId, relation.GenreId});

            builder.Property(vg => vg.VideoId).HasColumnName("id_video");
            builder.Property(vg => vg.GenreId).HasColumnName("id_genre");
        }
    }
}
