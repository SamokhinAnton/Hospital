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
        Task<IEnumerable<T>> GetPatientDoctors(int id);

        Task<IEnumerable<T>> GetNotPatientDoctors(int id);

        Task AddDoctorToPatient(int doctorId, int pacientId);
    }
}
