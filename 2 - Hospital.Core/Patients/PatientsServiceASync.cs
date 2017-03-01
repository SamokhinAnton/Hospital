using Hospital.Core.Diseases;
using Hospital.Core.Diseases.Models;
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

        IDiseasesRepositoryAsync<DiseaseDto> _diseasesRepository;

        public PatientsServiceAsync(IPatientsRepositoryAsync<PatientDto> patientsRepository, IDoctorsRepositoryAsync<DoctorDto> doctorsRepository, IDiseasesRepositoryAsync<DiseaseDto> diseasesRepository)
        {
            this._patientsRepository = patientsRepository;
            this._doctorsRepository = doctorsRepository;
            this._diseasesRepository = diseasesRepository;
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var patient = await _patientsRepository.GetByIdAsync(id);
            patient.Doctors = (await _doctorsRepository.GetPatientDoctorsAsync(id)).ToList();
            patient.Diseases = (await _diseasesRepository.GetPatientDiseasesAsync(id)).ToList();
            return patient;
        }
    }

}
