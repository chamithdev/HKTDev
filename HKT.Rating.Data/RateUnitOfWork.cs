using HKT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HKT.Rating.Data
{
    public class RateUnitOfWork : IUnitOfWork<RateContext>
    {

        RateContext _context;
        public RateUnitOfWork(RateContext context)
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

        public void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity, TContext> Repository<TEntity, TContext>()
            where TEntity : class
            where TContext : DbContext
        {
            throw new NotImplementedException();
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
