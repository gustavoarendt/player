using PlayerControl.Application.UseCases.Videos.Models;

namespace PlayerControl.Application.Extensions
{
    public static class FileExtensions
    {
        public static FileInputModel? ToFileInput(this IFormFile formFile)
        {
            if (formFile is null) return null;
            var fileStream = new MemoryStream();
            formFile.CopyTo(fileStream);
            return new FileInputModel(
                Path.GetExtension(formFile.FileName),
                fileStream);
        }
    }
}
