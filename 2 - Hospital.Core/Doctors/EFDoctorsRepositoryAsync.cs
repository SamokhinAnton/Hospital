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
        private HospitalContext _context;
        public EFDoctorsRepositoryAsync()
        {
            _context = new HospitalContext();
        }

        public override async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctor = await Task.Run(() => _context.Doctors.ToList());
            return doctor;
        }

        public async override Task CreateAsync(DoctorDto model)
        {
            await Task.Run(async () =>
            {
                _context.Doctors.Add(model);
                await _context.SaveChangesAsync();
            });
        }

        public async override Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async override Task<DoctorDto> GetByIdAsync(int id)
        {
            _context.Configuration.LazyLoadingEnabled = false;
            var doctor = await _context.Doctors.FindAsync(id);
            return doctor;
        }

        public async override Task UpdateAsync(DoctorDto model)
        {
            var doctor = await _context.Doctors.FindAsync(model.Id);
            doctor.Name = model.Name;
            doctor.Specialization = model.Specialization;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorDto>> GetPatientDoctorsAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            var doctors = patient.Doctors.ToList();
            return doctors;
        }

        public async Task<IEnumerable<DoctorDto>> GetNotPatientDoctorsAsync(int id)
        {
            var doctors = await Task.Run(() => _context.Doctors.Where(d => d.Patients.All(p => p.Id != id)));
            return doctors;
        }

        public async Task AddDoctorToPatientAsync(int doctorId, int pacientId)
        {
            var patient = await _context.Patients.FindAsync(pacientId);
            var doctor = await _context.Doctors.FindAsync(doctorId);
            patient.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }        

        public async Task RemovePatientAsync(int doctorId, int pacientId)
        {
            var patient = await _context.Patients.FindAsync(pacientId);
            var doctor = await _context.Doctors.FindAsync(doctorId);
            patient.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorDto>> SearchAsync(string pattern)
        {
            var doctors = await Task.Run(() => _context.Doctors
                .Where(d => d.Name.Contains(pattern) || d.Specialization.Contains(pattern)).ToList());
            return doctors;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
