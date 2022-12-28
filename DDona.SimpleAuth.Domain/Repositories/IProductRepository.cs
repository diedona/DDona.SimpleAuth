using DDona.SimpleAuth.Domain.Entities;

namespace DDona.SimpleAuth.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsWithCategories();
    }
}
