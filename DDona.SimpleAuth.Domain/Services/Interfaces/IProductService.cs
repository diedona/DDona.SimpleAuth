using DDona.SimpleAuth.Domain.Entities;

namespace DDona.SimpleAuth.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsWithCategories();
    }
}
