using Hospital.Core.Diseases.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors.Models
{
    [Table("Doctors")]
    public class DoctorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Specialization { get; set; }

        public virtual List<PatientDto> Patients { get; set; }

        public virtual List<DiseaseDto> Diseases { get; set; }
    }
}
