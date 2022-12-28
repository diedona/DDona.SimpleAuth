using DDona.SimpleAuth.Domain.Entities.Base;

namespace DDona.SimpleAuth.Domain.Entities
{
    public class Category : BaseEntity
    {
        private readonly List<Product> _Products = new List<Product>();

        public string Name { get; private set; }
        public IReadOnlyCollection<Product> Products => _Products.AsReadOnly();

        public Category(string name)
        {
            Name = name;
        }
    }
}
