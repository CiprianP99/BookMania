using BookMania.Interfaces;
using BookMania.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookMania.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BookContext BookContext { get; set; }

        public RepositoryBase(BookContext bookcontext)
        {
            this.BookContext = bookcontext;
        }

        public IQueryable<T> FindAll()
        {
            return this.BookContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.BookContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.BookContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.BookContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.BookContext.Set<T>().Update(entity);
        }
    }
}
