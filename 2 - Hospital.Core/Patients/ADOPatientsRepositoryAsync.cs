using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
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
                        var patient = await Task.Run(() => PatientParser(reader));
                        patients.Add(patient);
                    }
                }
                return patients;
            }
        }

        public PatientDto PatientParser(SqlDataReader reader)
        {
            var patient = new PatientDto()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Birthdate = reader.GetDateTime(2)
            };
            return patient;
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
                    var patient = await Task.Run(() => PatientParser(reader));
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
    }
}
