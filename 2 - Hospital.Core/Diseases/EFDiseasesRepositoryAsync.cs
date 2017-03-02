using Hospital.Core.Diseases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Diseases
{
    public class EFDiseasesRepositoryAsync : RepositoryAsync<DiseaseDto>,
        IDiseasesRepositoryAsync<DiseaseDto>
    {

        public override async Task CreateAsync(DiseaseDto model)
        {
            using (var context = new HospitalContext())
            {
                context.Diseases.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task CloseDiseaseAsync(int id, DateTime endAt)
        {
            using (var context = new HospitalContext())
            {
                var disease = await context.Diseases.FindAsync(id);
                disease.EndAt = endAt;
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DiseaseDto>> GetDoctorDiseasesAsync(int doctorId)
        {
            using (var context = new HospitalContext())
            {
                var doctor = await context.Doctors.FindAsync(doctorId);
                var diseases = doctor.Diseases.Select(d =>
                    new DiseaseDto
                    {
                        Id = d.Id,
                        DoctorId = d.DoctorId,
                        PatientId = d.PatientId,
                        StartAt = d.StartAt,
                        Name = d.Name,
                        ProfileName = d.Patient.Name,
                        EndAt = d.EndAt
                    }).ToList();
                return diseases;
            }
        }

        public async Task<IEnumerable<DiseaseDto>> GetPatientDiseasesAsync(int patientId)
        {
            using (var context = new HospitalContext())
            {
                var patient = await context.Patients.FindAsync(patientId);
                var diseases = patient.Diseases.Select(d =>
                    new DiseaseDto
                    {
                        Id = d.Id,
                        DoctorId = d.DoctorId,
                        PatientId = d.PatientId,
                        StartAt = d.StartAt,
                        Name = d.Name,
                        ProfileName = d.Doctor.Name,
                        EndAt = d.EndAt
                    }).ToList();
                return diseases;
            }
        }
    }
}
