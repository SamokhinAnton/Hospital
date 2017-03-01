using Hospital.Core.Diseases;
using Hospital.Core.Diseases.Models;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public class DoctorServiceAsync : IDoctorServiceAsync<DoctorDto>
    {
        IPatientsRepositoryAsync<PatientDto> _patientsRepository;

        IDoctorsRepositoryAsync<DoctorDto> _doctorsRepository;

        IDiseasesRepositoryAsync<DiseaseDto> _diseasesRepository;

        public DoctorServiceAsync(IPatientsRepositoryAsync<PatientDto> patientsRepository, IDoctorsRepositoryAsync<DoctorDto> doctorsRepository, IDiseasesRepositoryAsync<DiseaseDto> diseasesRepository)
        {
            this._patientsRepository = patientsRepository;
            this._doctorsRepository = doctorsRepository;
            this._diseasesRepository = diseasesRepository;
        }


        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            var doctor = await _doctorsRepository.GetByIdAsync(id);
            doctor.Patients = (await _patientsRepository.GetDoctorPatientsAsync(id)).ToList();
            doctor.Diseases = (await _diseasesRepository.GetDoctorDiseasesAsync(id)).ToList();
            return doctor;
        }
    }
}
