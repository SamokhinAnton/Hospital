using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public class ADODoctorsRepositoryAsync : RepositoryAsync<DoctorDto>, 
        IDoctorsRepositoryAsync<DoctorDto>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["HospitalContext"].ConnectionString;

        public async override Task CreateAsync(DoctorDto model)
        {
            string sql = "exec [dbo].[CreateDoctor] @name, @specialization";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("name", model.Name);
                command.Parameters.AddWithValue("specialization", model.Specialization);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async override Task DeleteAsync(int id)
        {
            string sql = "exec [dbo].[DeleteDoctor] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public override Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<DoctorDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(DoctorDto model)
        {
            throw new NotImplementedException();
        }
    }
}
