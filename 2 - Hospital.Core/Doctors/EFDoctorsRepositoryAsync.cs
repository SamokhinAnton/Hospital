using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public class EFDoctorsRepositoryAsync : RepositoryAsync<DoctorDto>,
        IDoctorsRepositoryAsync<DoctorDto>
    {
        private HospitalContext context;
        public EFDoctorsRepositoryAsync()
        {
            context = new HospitalContext();
        }

        public override async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var result = await Task.Run(() => context.Doctors.ToList());
            return result;
        }

 
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

        public Task<IEnumerable<DoctorDto>> SearchAsync(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
