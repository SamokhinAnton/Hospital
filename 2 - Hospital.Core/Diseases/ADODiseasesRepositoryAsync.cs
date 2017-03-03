using Hospital.Core.Diseases.Models;
using Hospital.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Diseases
{
    public class ADODiseasesRepositoryAsync : RepositoryAsync<DiseaseDto>,
        IDiseasesRepositoryAsync<DiseaseDto>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["HospitalContext"].ConnectionString;

        public async Task<IEnumerable<DiseaseDto>> GetPatientDiseasesAsync(int patientId)
        {
            var diseases = new List<DiseaseDto>();
            string sql = "exec [dbo].[GetPatientDiseasesHistory] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", patientId);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var disieas = await ParserExtension.DiseaseParser(reader);
                        diseases.Add(disieas);
                    }
                }
                return diseases;
            }
        }

        public override async Task CreateAsync(DiseaseDto model)
        {
            string sql = "exec [dbo].[CreateDisease] @patientId, @doctorId, @name, @startAt";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("patientId", model.PatientId);
                command.Parameters.AddWithValue("doctorId", model.DoctorId);
                command.Parameters.AddWithValue("name", model.Name);
                command.Parameters.AddWithValue("startAt", model.StartAt);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task CloseDiseaseAsync(int id, DateTime endAt)
        {
            string sql = "exec [dbo].[CloseDisease] @id, @endAt";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("endAt", endAt);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<DiseaseDto>> GetDoctorDiseasesAsync(int doctorId)
        {
            var diseases = new List<DiseaseDto>();
            string sql = "exec [dbo].[GetDoctorDiseases] @doctorId";
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
                        var disieas = await ParserExtension.DiseaseParser(reader);
                        diseases.Add(disieas);
                    }
                }
                return diseases;
            }
        }
    }
}
