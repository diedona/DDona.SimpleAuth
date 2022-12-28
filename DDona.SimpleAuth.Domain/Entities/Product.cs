using DDona.SimpleAuth.Domain.Entities.Base;
using DDona.SimpleAuth.Domain.Enums;

namespace DDona.SimpleAuth.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public ProductUnitEnum Unit { get; private set; }
        public decimal UnitValue { get; private set; }
        public Category Category { get; private set; }

        private Product() { }

        public Product(string name, ProductUnitEnum unit, decimal unitValue, Category category) : base()
        {
            Name = name;
            Unit = unit;
            UnitValue = unitValue;
            Category = category;
        }
    }
}
