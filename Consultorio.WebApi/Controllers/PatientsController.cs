using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Consultorio.WebApi.Data;
using Consultorio.WebApi.Models;
using Consultorio.WebApi.Services;

namespace Consultorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _PatientsService;

        public PatientsController(IPatientService patientsService)
        {
            _PatientsService = patientsService;
        }
        
        // POST: api/Patients
        [HttpPost]
        async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            await _PatientsService.AddPatientAsync(patient)
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.DNI }, patient);
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var Patients = await _PatientsService.GetPatientsAsync();
            return Patients;
        }
        
        // GET: api/Patients/5
        [HttpGet("{dni}")]
        public async Task<ActionResult<Patient>> GetPatient(int dni)
        {
            var patient = await _PatientsService.GetPatientAsync(dni);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        // // PUT: api/Patients/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPatient(int id, Patient patient)
        // {
        //     if (id != patient.DNI)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(patient).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PatientExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }


        // private bool PatientExists(int id)
        // {
        //     return _context.Patients.Any(e => e.DNI == id);
        // }
    }
}
