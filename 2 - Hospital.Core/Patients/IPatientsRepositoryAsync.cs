﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public interface IPatientsRepositoryAsync<T> : IRepositoryAsync<T> 
         where T: class
    {
        Task RemoveDoctorAsync(int patientId, int doctorId);

        Task<IEnumerable<T>> GetDoctorPatientsAsync(int doctorId);

        Task<IEnumerable<T>> SearchAsync(string pattern);
    }
}
