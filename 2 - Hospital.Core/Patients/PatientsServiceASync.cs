using Hospital.Core.Doctors;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public class PatientsServiceAsync : IPatientsServiceAsync<PatientDto>
    {
        IPatientsRepositoryAsync<PatientDto> _patientsRepository;

        IDoctorsRepositoryAsync<DoctorDto> _doctorsRepository;

        public PatientsServiceAsync(IPatientsRepositoryAsync<PatientDto> patientsRepository, IDoctorsRepositoryAsync<DoctorDto> doctorsRepository)
        {
            this._patientsRepository = patientsRepository;
            this._doctorsRepository = doctorsRepository;
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var patient = await _patientsRepository.GetByIdAsync(id);
            patient.Doctors = await _doctorsRepository.GetPatientDoctors(id);
            return patient;
        }
    }

}
