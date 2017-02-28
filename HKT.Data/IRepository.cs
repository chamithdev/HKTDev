using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HKT.Data
{
    public interface IRepository<TEntity, TContext>  where TEntity : class where TContext : DbContext
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        IEnumerable<TEntity> GetWithInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);
    }
}
