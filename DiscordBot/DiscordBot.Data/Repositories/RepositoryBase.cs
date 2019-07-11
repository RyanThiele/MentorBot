using DiscordBot.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{

    public abstract class RepositoryBase<TContext, TEntity> : IRepository<TEntity> where TEntity : class where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public RepositoryBase()
        {
            _context = new TContext();
        }

        public int Count() => _context.Set<TEntity>().Count();

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

        public void Insert(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public Task SaveAsync() => _context.SaveChangesAsync();

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Where(expression);

        public IQueryable<TEntity> Slice(int begin, int end) => _context.Set<TEntity>().Skip(begin).Take(end);

        #region IDisposable
        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
