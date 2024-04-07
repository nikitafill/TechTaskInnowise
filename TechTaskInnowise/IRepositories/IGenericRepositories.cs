using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTaskInnowise.IRepositories
{
    public interface IGenericRepositories<T> where T : class, new()
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetListAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}