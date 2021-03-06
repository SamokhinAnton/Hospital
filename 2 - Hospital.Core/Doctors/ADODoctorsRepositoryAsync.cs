﻿using Hospital.Core.Diseases.Models;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Utilities;

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

        public async override Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctors = new List<DoctorDto>();
            string sql = "exec [dbo].[GetAllDoctors]";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var doctor = await ParserExtension.DoctorParser(reader);
                        doctors.Add(doctor);
                    }
                }
                return doctors;
            }
        }

        public async override Task<DoctorDto> GetByIdAsync(int id)
        {
            string sql = "exec [dbo].[GetDoctor] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    reader.Read();
                    var doctor = await ParserExtension.DoctorParser(reader);
                    return doctor;
                }
            }
        }

        public async override Task UpdateAsync(DoctorDto model)
        {
            string sql = "exec [dbo].[UpdateDoctor] @id, @name, @specialization";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", model.Id);
                command.Parameters.AddWithValue("name", model.Name);
                command.Parameters.AddWithValue("specialization", model.Specialization);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<DoctorDto>> GetPatientDoctorsAsync(int id)
        {
            var doctors = new List<DoctorDto>();
            string sql = "exec [dbo].[GetPatientDoctors] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var doctor = await ParserExtension.DoctorParser(reader);
                        doctors.Add(doctor);
                    }
                }
                return doctors;
            }
        }

        public async Task<IEnumerable<DoctorDto>> GetNotPatientDoctorsAsync(int id)
        {
            var doctors = new List<DoctorDto>();
            string sql = "exec [dbo].[GetNotPatientDoctors] @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var doctor = await ParserExtension.DoctorParser(reader);
                        doctors.Add(doctor);
                    }
                }
                return doctors;
            }
        }

        public async Task AddDoctorToPatientAsync(int doctorId, int pacientId)
        {
            string sql = "exec [dbo].[CreateDoctorPatient] @patientId, @doctorId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = sql;
                command.Parameters.AddWithValue("patientId", pacientId);
                command.Parameters.AddWithValue("doctorId", doctorId);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task RemovePatientAsync(int patientId, int doctorId)
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

        public async Task<IEnumerable<DoctorDto>> SearchAsync(string pattern)
        {
            var doctors = new List<DoctorDto>();
            string sql = "exec [dbo].[SearchDoctors] @pattern";
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
                        var doctor = await ParserExtension.DoctorParser(reader);
                        doctors.Add(doctor);
                    }
                }
                return doctors;
            }
        }
    }
}
