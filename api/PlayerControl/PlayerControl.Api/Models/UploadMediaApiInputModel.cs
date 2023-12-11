using Microsoft.AspNetCore.Mvc;
using PlayerControl.Application.Extensions;
using PlayerControl.Application.UseCases.Videos.Commands;

namespace PlayerControl.Application.UseCases.Videos.Models
{
    public class UploadMediaApiInputModel
    {
        private static class MediaType
        {
            public const string Image = "image";
            public const string Video = "video";
        }

        [FromForm(Name = "media_file")]
        IFormFile Media { get; set; }

        public UploadMediaCommand ToUploadMediaInput(Guid id, string type)
        {
            return type?.ToLower() switch
            {
                MediaType.Video => new UploadMediaCommand(id, VideoFile: Media.ToFileInput()),
                MediaType.Image => new UploadMediaCommand(id, ImageFile: Media.ToFileInput()),
                _ => throw new ArgumentException("Invalid type")
            };
        }
    }
}
