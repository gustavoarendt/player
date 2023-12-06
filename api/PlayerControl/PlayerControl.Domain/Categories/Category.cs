using PlayerControl.Domain.Commons;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Domain.Categories
{
    public class Category : Entity
    {
        public Category(string name, string description) : base()
        {
            Name = name;
            Description = description ?? "";
            IsActive = true;
            Validate();
        }

        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

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

        public void UpdateData(string name, string description)
        {
            Name = name ?? Name;
            Description = description ?? Description;
        }

        private void Validate()
        {
            DomainValidation.IsNullOrWhitespace(Name, nameof(Name));
            DomainValidation.MinLength(Name, 3, nameof(Name));
            DomainValidation.MaxLength(Name, 255, nameof(Name));
        }
    }
}
