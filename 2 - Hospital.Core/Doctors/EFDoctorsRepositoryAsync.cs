using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    class EFDoctorsRepositoryAsync : RepositoryAsync<DoctorDto>,
        IDoctorsRepositoryAsync<DoctorDto>
    {

    }
}
