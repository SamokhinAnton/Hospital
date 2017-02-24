using Hospital.Core.Diseases.Models;
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

        public async Task<IEnumerable<DiseaseDto>> GetPatientDiseases(int patientId)
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
                        var disieas = await DiseaseParser(reader);
                        diseases.Add(disieas);
                    }
                }
                return diseases;
            }
        }

        private async Task<DiseaseDto> DiseaseParser(SqlDataReader reader)
        {
            var disease = new DiseaseDto
            {
                Id = await reader.GetFieldValueAsync<int>(0),
                PatientId = await reader.GetFieldValueAsync<int>(1),
                DoctorId = await reader.GetFieldValueAsync<int>(2),
                Name = await reader.GetFieldValueAsync<string>(3),
                StartAt = await reader.GetFieldValueAsync<DateTime>(4),
                EndAt = await reader.IsDBNullAsync(5) ? null : await reader.GetFieldValueAsync<DateTime?>(5)
            };
            return disease;
        }
    }
}
