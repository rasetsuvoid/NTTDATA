using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task<int> AddWithIdAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
