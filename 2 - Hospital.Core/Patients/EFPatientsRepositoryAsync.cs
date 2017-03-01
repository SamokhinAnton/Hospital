using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public class EFPatientsRepositoryAsync : RepositoryAsync<PatientDto>,
        IPatientsRepositoryAsync<PatientDto>
    {



        public Task<IEnumerable<PatientDto>> GetDoctorPatientsAsync(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDoctorAsync(int patientId, int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientDto>> SearchAsync(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
