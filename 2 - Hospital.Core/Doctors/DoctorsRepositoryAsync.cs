using Hospital.Core.Doctors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Doctors
{
    public class DoctorsRepositoryAsync : RepositoryAsync<DoctorDto>, 
        IDoctorsRepositoryAsync<DoctorDto>
    {
        public override Task CreateAsync(DoctorDto model)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
