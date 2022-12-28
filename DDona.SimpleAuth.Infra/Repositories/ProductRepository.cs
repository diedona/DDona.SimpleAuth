using DDona.SimpleAuth.Domain.Entities;
using DDona.SimpleAuth.Domain.Repositories;
using DDona.SimpleAuth.Infra.Context;
using DDona.SimpleAuth.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SimpleAuthDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _DbSet.ToListAsync();
        }
    }
}
