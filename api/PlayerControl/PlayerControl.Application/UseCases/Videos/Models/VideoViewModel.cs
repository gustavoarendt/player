﻿using PlayerControl.Domain.Entities.Videos;
using PlayerControl.Domain.Entities.Videos.Enums;

namespace PlayerControl.Application.UseCases.Videos.Models
{
    public record VideoViewModel(Guid Id, string Title, string Description, int Year, int Duration, Rating Rating, DateTime CreatedAt, IReadOnlyCollection<Guid> CategoryIds, IReadOnlyCollection<Guid> GenreIds, string? ImagePath, string? MediaPath)
    {
        public static VideoViewModel FromEntity(Video video)
        {
            return new VideoViewModel(video.Id, video.Title, video.Description, video.Year, video.Duration, video.Rating, video.CreatedAt, video.Categories, video.Genres, video.Image?.Path, video.Media?.FilePath);
        }
    }
}
