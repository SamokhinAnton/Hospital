using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public interface IPatientsServiceAsync<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
    }
}
