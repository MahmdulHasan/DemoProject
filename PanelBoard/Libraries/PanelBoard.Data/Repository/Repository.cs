using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PanelBoard.Data.Repository
{
   
        public abstract class Repository<T>
         : IRepository<T> where T : class
        {
            protected DbSet<T> _dbSet;
            public Repository(DbContext context)
            {
                _dbSet = context.Set<T>();
                
            }
            public void Add(T entity)
            {
                _dbSet.Add(entity);
            }

            public void AddRange(IEnumerable<T> entities)
            {
                _dbSet.AddRange(entities);
            }

            public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            {
                if (predicate == null)
                {
                    return _dbSet;
                }
                else
                {
                    return _dbSet.Where(predicate);
                }
            }

            public IEnumerable<T> GetAll()
            {
                return _dbSet.ToList();
            }

            public T GetById(int id)
            {
                return _dbSet.Find(id);
            }

            public void Remove(T entity)
            {
                _dbSet.Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entities)
            {
                _dbSet.RemoveRange(entities);
            }
        }
    }

