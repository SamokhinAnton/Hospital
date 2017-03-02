using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public class EFDoctorsRepositoryAsync : RepositoryAsync<DoctorDto>,
        IDoctorsRepositoryAsync<DoctorDto>
    {
        public override async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            using (var context = new HospitalContext())
            {
                var doctor = await context.Doctors.ToListAsync();
                return doctor;
            }
        }

        public async override Task CreateAsync(DoctorDto model)
        {
            using (var context = new HospitalContext())
            {
                context.Doctors.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public async override Task DeleteAsync(int id)
        {
            using (var context = new HospitalContext())
            {
                var doctor = await context.Doctors.FindAsync(id);
                context.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
            }
        }

        public async override Task<DoctorDto> GetByIdAsync(int id)
        {
            using (var context = new HospitalContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var doctor = await context.Doctors.FindAsync(id);
                return doctor;
            }
        }

        public async override Task UpdateAsync(DoctorDto model)
        {
            using (var context = new HospitalContext())
            {
                var doctor = await context.Doctors.FindAsync(model.Id);
                doctor.Name = model.Name;
                doctor.Specialization = model.Specialization;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DoctorDto>> GetPatientDoctorsAsync(int id)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(id);
                var doctors = patient.Doctors;
                return doctors;
            }
        }

        public async Task<IEnumerable<DoctorDto>> GetNotPatientDoctorsAsync(int id)
        {
            using (var context = new HospitalContext())
            {
                var doctors = await context.Doctors.Where(d => d.Patients.All(p => p.Id != id)).ToListAsync();
                return doctors;
            }
        }

        public async Task AddDoctorToPatientAsync(int doctorId, int pacientId)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(pacientId);
                var doctor = await context.Doctors.FindAsync(doctorId);
                patient.Doctors.Add(doctor);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemovePatientAsync(int doctorId, int pacientId)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(pacientId);
                var doctor = await context.Doctors.FindAsync(doctorId);
                patient.Doctors.Remove(doctor);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DoctorDto>> SearchAsync(string pattern)
        {
            using (var context = new HospitalContext())
            {
                var doctors = await context.Doctors
                    .Where(d => d.Name.Contains(pattern) || d.Specialization.Contains(pattern)).ToListAsync();
                return doctors;
            }
        }
    }
}
