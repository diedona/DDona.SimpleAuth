using DDona.SimpleAuth.Domain.Entities;
using DDona.SimpleAuth.Domain.Repositories;

namespace DDona.SimpleAuth.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _ProductRepository.GetAllProducts();
        }
    }
}
