using DDona.SimpleAuth.Domain.Entities;
using DDona.SimpleAuth.Domain.Repositories;
using DDona.SimpleAuth.Domain.Services.Interfaces;
using DDona.SimpleAuth.Domain.UnitOfWork;

namespace DDona.SimpleAuth.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IProductRepository _ProductRepository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _ProductRepository = _UnitOfWork.ProductRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _ProductRepository.GetAllProducts();
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithCategories()
        {
            return await _ProductRepository.GetAllProductsWithCategories();
        }
    }
}
