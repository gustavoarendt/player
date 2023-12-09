using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Genres;

namespace PlayerControl.Domain.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<IEnumerable<Genre>> List();
        public Task<IEnumerable<Guid>> GetIdListByIds(ICollection<Guid> ids);
    }
}
