using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task CreateAsync(T model);

        Task DeleteAsync(int id);

        Task UpdateAsync(T model);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
    }
}
