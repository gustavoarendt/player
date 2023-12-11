using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayerControl.Domain.Entities.Videos;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Videos.Mappings
{
    public class VideoCategoriesMapping : IEntityTypeConfiguration<VideoCategories>
    {
        public void Configure(EntityTypeBuilder<VideoCategories> builder)
        {
            builder.ToTable("video_category");
            builder.HasKey(relation => new { relation.VideoId, relation.CategoryId });

            builder.Property(vc => vc.VideoId).HasColumnName("id_video");
            builder.Property(vc => vc.CategoryId).HasColumnName("id_category");
        }
    }
}
