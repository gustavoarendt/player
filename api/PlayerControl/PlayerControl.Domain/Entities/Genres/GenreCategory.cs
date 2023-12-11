using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Entities.Categories;

namespace PlayerControl.Domain.Entities.Genres
{
    public class GenreCategory
    {
        public GenreCategory(Guid genreId, Guid categoryId) : base()
        {
            GenreId = genreId;
            CategoryId = categoryId;
        }

        public Guid GenreId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Genre? Genre { get; private set; }
        public Category? Category { get; private set; }
    }
}
