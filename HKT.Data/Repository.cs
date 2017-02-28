using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace HKT.Data
{
    public class Repository<TEntity,TContext> : IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _context;
       

       
        //private readonly IUnitOfWork _unitOfWork;

        public Repository(TContext context)
        {
            _context = context;
          
           // _unitOfWork = unitOfWork;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Add(entity);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetWithInclude<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
           return _context.Set<TEntity>().Include(navigationPropertyPath);
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Remove(entity);
            }
        }
    }
}
