using DDona.SimpleAuth.Domain.Repositories;

namespace DDona.SimpleAuth.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
