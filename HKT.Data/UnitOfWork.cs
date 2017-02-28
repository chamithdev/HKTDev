using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace HKT.Data
{
    public class UnitOfWork<TDbContext> where TDbContext : DbContext, IUnitOfWork<TDbContext>
    {
        TDbContext _context;
        public UnitOfWork(TDbContext context)
        {
            _context = context;
        }
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            throw new NotImplementedException();
        }

        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity, TContext> Repository<TEntity, TContext>() where TEntity : class where TContext : DbContext
        {
          return Repository<TEntity, TContext>();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
