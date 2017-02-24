using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Diseases
{
    public interface IDiseasesRepositoryAsync<T> : IRepositoryAsync<T> where T: class
    {
        Task<IEnumerable<T>> GetPatientDiseases(int patientId);
    }
}
