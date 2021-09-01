using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Add(T entitiy)
        {
            dbSet.Add(entitiy);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> condition)
        {
            return dbSet.Where(condition);
            
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
           
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
