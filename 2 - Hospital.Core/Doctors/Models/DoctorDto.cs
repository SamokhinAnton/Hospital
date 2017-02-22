using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors.Models
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }
    }
}
