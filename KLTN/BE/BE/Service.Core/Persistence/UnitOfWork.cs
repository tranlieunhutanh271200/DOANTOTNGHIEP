using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Service.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Core.Persistence
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        private static Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private TContext _context;
        private IDbContextTransaction _objTran;
        private IConfiguration _configuration;
        private bool _disposed;
        private bool _disposing;
        private IServiceProvider _serviceProvider;

        public UnitOfWork(TContext context, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _context = context;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public R GetRequiredRepository<I, R>()
        {
            var type = typeof(R);
            if (!typeof(I).IsAssignableFrom(typeof(R)))
            {
                return default(R);
            }
            var instance = (R)Activator.CreateInstance(type, _context, _configuration);
            return instance;
        }
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public void Dispose()
        {
            _disposing = true;
            if (!_disposed)
                if (_disposing)
                    _context.Dispose();
            _disposing = false;
            _disposed = true;
        }
    }
}
