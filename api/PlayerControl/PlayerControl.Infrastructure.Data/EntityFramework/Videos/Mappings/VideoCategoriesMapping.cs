using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlayerControl.Domain.Entities.Videos;

namespace PlayerControl.Infrastructure.Data.EntityFramework.Videos.Mappings
{
    public class VideoCategoriesMapping : IEntityTypeConfiguration<VideoCategories>
    {
        public void Configure(EntityTypeBuilder<VideoCategories> builder)
        {
            builder.HasKey(relation => new { relation.VideoId, relation.CategoryId });
        }
    }
}
