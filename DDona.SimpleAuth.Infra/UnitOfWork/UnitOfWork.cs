using DDona.SimpleAuth.Domain.Repositories;
using DDona.SimpleAuth.Domain.UnitOfWork;
using DDona.SimpleAuth.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDona.SimpleAuth.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposedValue;
        private readonly SimpleAuthDbContext _Context;
        private readonly IProductRepository _ProductRepository;

        public IProductRepository ProductRepository => _ProductRepository;

        public UnitOfWork(SimpleAuthDbContext context, IProductRepository productRepository)
        {
            _Context = context;
            _ProductRepository = productRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _Context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
