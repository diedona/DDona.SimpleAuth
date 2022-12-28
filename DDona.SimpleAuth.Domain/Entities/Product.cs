using DDona.SimpleAuth.Domain.Entities.Base;
using DDona.SimpleAuth.Domain.Enums;

namespace DDona.SimpleAuth.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public ProductUnitEnum Unit { get; set; }
        public decimal UnitValue { get; set; }

        public Product(string name, ProductUnitEnum unit, decimal unitValue)
        {
            Name = name;
            Unit = unit;
            UnitValue = unitValue;
        }
    }
}
