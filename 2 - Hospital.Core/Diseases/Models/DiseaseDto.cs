using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Diseases.Models
{
    public class DiseaseDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Name { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public string ProfileName { get; set; }

        public IEnumerable<PatientDto> Patients { get; set; }

        public IEnumerable<DoctorDto> Doctors { get; set; }
    }
}
