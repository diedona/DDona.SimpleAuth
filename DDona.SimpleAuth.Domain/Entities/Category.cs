using DDona.SimpleAuth.Domain.Entities.Base;

namespace DDona.SimpleAuth.Domain.Entities
{
    public class Category : BaseEntity
    {
        private readonly List<Product> _Products = new();

        public string Name { get; private set; }
        public IReadOnlyCollection<Product> Products => _Products.AsReadOnly();

        public Category(string name) : base()
        {
            Name = name;
        }
    }
}
