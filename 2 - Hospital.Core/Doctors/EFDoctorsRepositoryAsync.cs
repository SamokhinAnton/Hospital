using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    class EFDoctorsRepositoryAsync : RepositoryAsync<DoctorDto>,
        IDoctorsRepositoryAsync<DoctorDto>
    {
        public Task AddDoctorToPatientAsync(int doctorId, int pacientId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoctorDto>> GetNotPatientDoctorsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoctorDto>> GetPatientDoctorsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemovePatientAsync(int doctorId, int pacientId)
        {
            throw new NotImplementedException();
        }
    }
}
