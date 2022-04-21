using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Interfaces.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity); 

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
    }
}