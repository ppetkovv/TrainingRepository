using Microsoft.EntityFrameworkCore;
using MyTwitter.Data.Models;
using MyTwitter.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyTwitter.Data.Repositories.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyTwitterDbContext context;

        public GenericRepository(MyTwitterDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> All => this.context.Set<T>().AsEnumerable<T>();

        public void Attach(T entity)
        {
            this.context.Entry(entity).State = EntityState.Unchanged;
        }

        public void Delete(T entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
        }

        public void Insert(T entity)
        {
            this.context.Entry(entity).State = EntityState.Added;
        }

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate).AsEnumerable();
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public DbSet<T> DbSet => this.context.Set<T>();
    }
}