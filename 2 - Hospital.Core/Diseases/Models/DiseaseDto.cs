using Hospital.Core.Doctors.Models;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Diseases.Models
{
    [Table("Diseases")]
    public class DiseaseDto
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateTime StartAt { get; set; }


        public DateTime? EndAt { get; set; }


        [NotMapped]
        public string ProfileName { get; set; }

        [ForeignKey("PatientId")]
        public virtual PatientDto Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual DoctorDto Doctor { get; set; }
    }
}
