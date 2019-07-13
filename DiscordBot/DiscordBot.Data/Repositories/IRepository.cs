using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Data.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        int Count();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        Task SaveAsync();
    }
}
