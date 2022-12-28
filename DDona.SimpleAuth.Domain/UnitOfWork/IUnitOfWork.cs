using DDona.SimpleAuth.Domain.Repositories;

namespace DDona.SimpleAuth.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
