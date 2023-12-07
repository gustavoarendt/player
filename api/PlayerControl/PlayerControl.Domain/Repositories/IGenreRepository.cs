using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Genres;

namespace PlayerControl.Domain.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<IEnumerable<Genre>> List();
    }
}
