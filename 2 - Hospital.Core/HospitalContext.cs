using Hospital.Core.Diseases.Models;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("HospitalContext")
        { }

        public DbSet<DoctorDto> Doctors { get; set; }

        public DbSet<PatientDto> Patients { get; set; }

        public DbSet<DiseaseDto> Diseases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorDto>().ToTable("Doctors");
            modelBuilder.Entity<PatientDto>().ToTable("Patients");
            modelBuilder.Entity<DiseaseDto>().ToTable("Diseases");
            base.OnModelCreating(modelBuilder);
        }
    }
}
