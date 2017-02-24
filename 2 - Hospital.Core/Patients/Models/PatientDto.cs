using Hospital.Core.Diseases.Models;
using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients.Models
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


        public IEnumerable<DoctorDto> Doctors { get; set; }

        public IEnumerable<DiseaseDto> Diseases { get; set; }

    }
}
