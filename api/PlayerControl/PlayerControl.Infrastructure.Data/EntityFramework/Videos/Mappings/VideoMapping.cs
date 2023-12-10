using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerControl.Domain.Entities.Videos;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Videos.Mappings
{
    internal class VideoMapping : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(v => v.Id);
            builder.ToTable("video");

            builder.Property(v => v.Id).HasColumnName("id_video").IsRequired();
            builder.Property(v => v.Title).HasColumnName("title").HasMaxLength(255).IsRequired();
            builder.Property(v => v.Description).HasColumnName("is_active").HasMaxLength(2000).IsRequired();
            builder.Property(v => v.Year).HasColumnName("year");
            builder.Property(v => v.Duration).HasColumnName("duration");
            builder.Property(v => v.Rating).HasColumnName("rating");
            builder.OwnsOne(v => v.Image, image => image.Property(i => i.Path).HasColumnName("image_path"));
            builder.OwnsOne(v => v.Media, media => media.Property(m => m.FilePath).HasColumnName("file_path"));
            builder.OwnsOne(v => v.Media, media => media.Property(m => m.EncodedPath).HasColumnName("encoded_path"));
        }
    }
}
