using Consultorio.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.Services
{
    public interface IPatientService
    {
        Task<bool> AddPatientAsync(Patient newPatient);
        Task<Patient[]> GetPatientsAsync();
        Task<Patient> GetPatientAsync(int dni);
        Task<bool> DeletePatientAsync(int dni);
        Task<bool> ModifyPatientAsync(Patient modPatient);
    }
}
