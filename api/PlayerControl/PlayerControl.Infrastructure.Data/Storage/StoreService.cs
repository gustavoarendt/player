using PlayerControl.Application.Interfaces;

namespace PlayerControl.Infrastructure.Data.Storage
{
    public class StoreService : IStoreService
    {
        public Task Delete(string? fileName)
        {
            Console.WriteLine("To be implemented");
            return Task.CompletedTask;
        }

        public Task<string> Upload(string fileName, Stream fileStream)
        {
            return Task.FromResult("To be implemented");
        }
    }
}
