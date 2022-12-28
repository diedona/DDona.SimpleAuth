using DDona.SimpleAuth.Domain.Entities.Base;
using DDona.SimpleAuth.Domain.Repositories.Base;
using DDona.SimpleAuth.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDona.SimpleAuth.Infra.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SimpleAuthDbContext _Context;
        protected readonly DbSet<T> _DbSet;

        public BaseRepository(SimpleAuthDbContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }
    }
}
