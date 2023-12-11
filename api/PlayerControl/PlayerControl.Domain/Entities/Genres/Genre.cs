using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Domain.Entities.Genres
{
    public class Genre : Entity
    {
        public Genre(string name) : base()
        {
            Name = name;
            IsActive = true;
            _categoryIds = new List<Guid>();
            Validate();
        }

        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        private List<Guid> _categoryIds;
        public IReadOnlyList<Guid> CategoryIds => _categoryIds.AsReadOnly();

        public ICollection<GenreCategory> GenreCategories { get; private set; } = new List<GenreCategory>();

        public void Deactivate()
        {
            IsActive = false;
            Validate();
        }

        public void Activate()
        {
            IsActive = true;
            Validate();
        }

        public void UpdateData(string? name)
        {
            Name = name ?? Name;
            Validate();
        }

        public void AddCategoryId(Guid categoryId)
        {
            _categoryIds.Add(categoryId);
            Validate();
        }
        public void RemoveCategoryId(Guid categoryId)
        {
            _categoryIds.Remove(categoryId);
            Validate();
        }

        public void RemoveAllCategoryIds()
        {
            _categoryIds.Clear();
            Validate();
        }

        public void UpdateGenresCategories(ICollection<GenreCategory> genresCategories)
        {
            GenreCategories = genresCategories;
        }

        private void Validate()
        {
            DomainValidation.IsNullOrWhitespace(Name, nameof(Name));
        }
    }
}
