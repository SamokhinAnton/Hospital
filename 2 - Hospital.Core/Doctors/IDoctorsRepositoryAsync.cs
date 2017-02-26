using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public interface IDoctorsRepositoryAsync<T> : IRepositoryAsync<T>
        where T : class
    {
        Task<IEnumerable<T>> GetPatientDoctorsAsync(int id);

        Task<IEnumerable<T>> GetNotPatientDoctorsAsync(int id);

        Task AddDoctorToPatientAsync(int doctorId, int pacientId);

        Task RemovePatientAsync(int doctorId, int pacientId);
    }
}
