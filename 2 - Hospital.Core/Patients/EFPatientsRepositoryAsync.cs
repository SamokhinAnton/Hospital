using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public class EFPatientsRepositoryAsync : RepositoryAsync<PatientDto>,
        IPatientsRepositoryAsync<PatientDto>
    {
        public async override Task CreateAsync(PatientDto model)
        {
            using (var context = new HospitalContext())
            {
                context.Patients.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public async override Task DeleteAsync(int id)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(id);
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();
            }
        }

        public async override Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            using (var context = new HospitalContext())
            {
                var patients = await context.Patients.ToListAsync();
                return patients;
            }
        }

        public async override Task<PatientDto> GetByIdAsync(int id)
        {
            using (var context = new HospitalContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var patient = await context.Patients.FindAsync(id);
                return patient;
            }
        }

        public async override Task UpdateAsync(PatientDto model)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(model.Id);
                patient.Birthdate = model.Birthdate;
                patient.Name = model.Name;
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveDoctorAsync(int patientId, int doctorId)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(patientId);
                var doctor = await context.Doctors.FindAsync(doctorId);
                doctor.Patients.Remove(patient);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PatientDto>> GetDoctorPatientsAsync(int doctorId)
        {
            using (var context = new HospitalContext())
            {
                var doctor = await context.Doctors.FindAsync(doctorId);
                var patients = doctor.Patients;
                return patients;
            }
        }

        public async Task<IEnumerable<PatientDto>> SearchAsync(string pattern)
        {
            using (var context = new HospitalContext())
            {
                var patients = await context.Patients
                    .Where(d => d.Name.Contains(pattern))
                    .ToListAsync();
                return patients;
            }
        }
    }
}
