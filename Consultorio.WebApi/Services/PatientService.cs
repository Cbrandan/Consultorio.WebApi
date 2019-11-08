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

        public async Task<bool> AddPatientAsync(Person person)
        {
            var newPatient = new Patient {
                DNI = person.DNI,
                Name = person.Name,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                Sex = person.Sex,
                HighDate = DateTime.Now,
                UserId = "user.Id"
            };

            _context.Patients.Add(newPatient);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<Patient[]> GetPatientsAsync()
        {
            return await _context.Patients.ToArrayAsync();
        }

        public async Task<Patient> GetPatientAsync(int dni)
        {
            var patient = await _context.Patients
            .Where(x => x.DNI == dni).FirstOrDefaultAsync();
            return patient;
        }

        public async Task<bool> DeletePatientAsync(int dni)
        {
            _context.RemoveRange(_context.Patients.Where(x => x.DNI == dni));
            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public Task<bool> ModifyPatientAsync(Patient modPatient)
        {
            throw new NotImplementedException();
        }
    }
}
