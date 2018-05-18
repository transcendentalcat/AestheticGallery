using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
