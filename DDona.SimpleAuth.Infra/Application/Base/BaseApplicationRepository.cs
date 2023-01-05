using DDona.SimpleAuth.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Application.Base
{
    public class BaseApplicationRepository<T> where T: class
    {
        protected readonly SimpleAuthDbContext _Context;
        protected readonly DbSet<T> _DbSet;

        public BaseApplicationRepository(SimpleAuthDbContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }
    }
}
