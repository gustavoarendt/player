namespace PlayerControl.Application.Interfaces
{
    public interface IStoreService
    {
        Task<string> Upload(string fileName, Stream fileStream);
        Task Delete(string? fileName);
    }
}
