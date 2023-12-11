using PlayerControl.Application.Interfaces;

namespace PlayerControl.Infrastructure.Data.Storage
{
    public class StoreService : IStoreService
    {
        public Task Delete(string? fileName)
        {
            throw new NotImplementedException();
        }

        public Task<string> Upload(string fileName, Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
