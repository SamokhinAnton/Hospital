using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public interface IDoctorServiceAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
    }
}
