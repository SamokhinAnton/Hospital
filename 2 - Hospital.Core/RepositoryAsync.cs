using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class RepositoryAsync<T> : IRepositoryAsync<T>
        where T : class
    {
        public virtual Task CreateAsync(T model)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
