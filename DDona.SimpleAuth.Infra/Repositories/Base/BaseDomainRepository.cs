using DDona.SimpleAuth.Domain.Entities.Base;
using DDona.SimpleAuth.Domain.Repositories.Base;
using DDona.SimpleAuth.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Repositories.Base
{
    public abstract class BaseDomainRepository<T> : IBaseDomainRepository<T> where T : BaseEntity
    {
        protected readonly SimpleAuthDbContext _Context;
        protected readonly DbSet<T> _DbSet;

        public BaseDomainRepository(SimpleAuthDbContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }
    }
}
