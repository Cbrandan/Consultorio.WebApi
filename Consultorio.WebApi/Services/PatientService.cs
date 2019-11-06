using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.WebApi.Data;
using Consultorio.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.WebApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient[]> GetPatientsAsync()
        {
            return await _context.Patients.ToArrayAsync();
        }

        public Task<Patient> GetPatientAsync(int dni)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddPatientAsync(Patient newPatient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePatientAsync(int dni)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyPatientAsync(Patient modPatient)
        {
            throw new NotImplementedException();
        }
    }
}
