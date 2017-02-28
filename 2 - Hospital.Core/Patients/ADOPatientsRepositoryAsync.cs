using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using Hospital.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public class ADOPatientsRepositoryAsync : RepositoryAsync<PatientDto>,
        IPatientsRepositoryAsync<PatientDto>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["HospitalContext"].ConnectionString;

        public async override Task CreateAsync(PatientDto model)
        {
            string sql = "exec [dbo].[CreatePatient] @name, @birthdate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("name", model.Name);
                command.Parameters.AddWithValue("birthdate", model.Birthdate);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async override Task DeleteAsync(int id)
        {
            string sql = "exec [dbo].[DeletePatient] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async override Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var patients = new List<PatientDto>();
            string sql = "exec [dbo].[GetAllPatients]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var patient = await ParserExtension.PatientParser(reader);
                        patients.Add(patient);
                    }
                }
                return patients;
            }
        }



        public async override Task<PatientDto> GetByIdAsync(int id)
        {
            string sql = "exec [dbo].[GetPatient] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    reader.Read();
                    var patient = await ParserExtension.PatientParser(reader);
                    return patient;
                }
            }
        }

        public async override Task UpdateAsync(PatientDto model)
        {
            string sql = "exec [dbo].[UpdatePatient] @id, @name, @birthdate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", model.Id);
                command.Parameters.AddWithValue("name", model.Name);
                command.Parameters.AddWithValue("birthdate", model.Birthdate);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task RemoveDoctorAsync(int patientId, int doctorId)
        {
            string sql = "exec [dbo].[DeleteDoctorFromPatient] @patientId, @doctorId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("patientId", patientId);
                command.Parameters.AddWithValue("doctorId", doctorId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<PatientDto>> GetDoctorPatientsAsync(int doctorId)
        {
            var patients = new List<PatientDto>();
            string sql = "exec [dbo].[GetDoctorPatients] @doctorId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("doctorId", doctorId);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var patient = await ParserExtension.PatientParser(reader);
                        patients.Add(patient);
                    }
                }
                return patients;
            }
        }

        public async Task<IEnumerable<PatientDto>> SearchAsync(string pattern)
        {
            var patients = new List<PatientDto>();
            string sql = "exec [dbo].[SearchPatients] @pattern";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("pattern", pattern);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var patient = await ParserExtension.PatientParser(reader);
                        patients.Add(patient);
                    }
                }
                return patients;
            }
        }
    }
}
