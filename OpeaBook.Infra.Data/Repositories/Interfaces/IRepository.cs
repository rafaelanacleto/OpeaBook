using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpeaBook.Infra.Data.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate);

    }
}
