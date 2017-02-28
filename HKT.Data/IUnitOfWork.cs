using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace HKT.Data
{
    public interface IUnitOfWork<TDbContext> where TDbContext : DbContext , IDisposable
    {

        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity,TContext> Repository<TEntity, TContext>() where TEntity : class where TContext : DbContext;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
