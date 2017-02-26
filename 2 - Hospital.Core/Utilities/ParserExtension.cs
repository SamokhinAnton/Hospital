using Hospital.Core.Diseases.Models;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Utilities
{
    public static class ParserExtension
    {
        public static async Task<DoctorDto> DoctorParser(SqlDataReader reader)
        {
            var doctor = new DoctorDto()
            {
                Id = await reader.GetFieldValueAsync<int>(0),
                Name = await reader.GetFieldValueAsync<string>(1),
                Specialization = await reader.GetFieldValueAsync<string>(2),
                Diseases = new List<DiseaseDto>(),
                Patients = new List<PatientDto>()
            };
            return doctor;
        }

        public static async Task<DiseaseDto> DiseaseParser(SqlDataReader reader)
        {
            var disease = new DiseaseDto
            {
                Id = await reader.GetFieldValueAsync<int>(0),
                PatientId = await reader.GetFieldValueAsync<int>(1),
                DoctorId = await reader.GetFieldValueAsync<int>(2),
                Name = await reader.GetFieldValueAsync<string>(3),
                StartAt = await reader.GetFieldValueAsync<DateTime>(4),
                EndAt = await reader.IsDBNullAsync(5) ? null : await reader.GetFieldValueAsync<DateTime?>(5),
                Doctors = new List<DoctorDto>(),
                Patients = new List<PatientDto>()
            };
            return disease;
        }

        public static async Task<PatientDto> PatientParser(SqlDataReader reader)
        {
            var patient = new PatientDto()
            {
                Id = await reader.GetFieldValueAsync<int>(0),
                Name = await reader.GetFieldValueAsync<string>(1),
                Birthdate = await reader.GetFieldValueAsync<DateTime>(2),
                Diseases = new List<DiseaseDto>(),
                Doctors = new List<DoctorDto>()
            };
            return patient;
        }
    }
}
