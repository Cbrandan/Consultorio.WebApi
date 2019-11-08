﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Consultorio.WebApi.Data;
using Consultorio.WebApi.Models;
using Consultorio.WebApi.Services;
using static Consultorio.WebApi.Data.Constants;
using Consultorio.WebApi.DTOs.Requests;
using AutoMapper;
using Consultorio.WebApi.DTOs.Responses;

namespace Consultorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _PatientsService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientsService, IMapper mapper)
        {
            _PatientsService = patientsService;
            _mapper = mapper;
        }

        // POST: api/Patients/AddPatient
        /// <summary>
        /// Crea el paciente en base a los datos enviados de una persona.
        /// </summary>
        /// <remarks>
        /// Ejemplo de request:
        ///
        ///     POST /Patient
        ///     {
        ///        "DNI": "30444555",
        ///        "Name": "Juan",
        ///        "LastName": "Perez",
        ///        "BirthDate": "01/01/1990"
        ///     }
        ///
        /// </remarks>
        /// <returns>Devuevle los datos del paciente creado</returns>
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient([FromBody] PatientAddDTO request)
        {
            var person = _mapper.Map<PatientAddDTO, Person>(request);

            var successful = await _PatientsService.AddPatientAsync(person);
            if (!successful)
            {
                return BadRequest("No se pudo agregar al paciente.");
            }
            return CreatedAtAction("GetPatient", new { id = person.DNI }, person);
        }

        // GET: api/Patients/Patient
        /// <summary>
        /// Devuelve datos del paciente según el DNI enviado.
        /// </summary>
        /// <returns>Datos del paciente.</returns>
        [HttpGet("{dni}")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int dni)
        {
            var patient = await _PatientsService.GetPatientAsync(dni);

            if (patient == null)
            {
                return NotFound();
            }

            var resources = _mapper.Map<Patient, PatientDTO>(patient);
            return Ok(resources);
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var Patients = await _PatientsService.GetPatientsAsync();
            return Patients;
        }

        // DELETE: api/Patients/5
        /// <summary>
        /// Elimina un paciente según el DNI enviado.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Retorna los datos del paciente eliminado.</returns>
        [HttpDelete("{dni}")]
        public async Task<ActionResult<Patient>> DeletePatient(int dni)
        {
            var patient = await _PatientsService.GetPatientAsync(dni);

            if (patient == null)
            {
                return NotFound();
            }

            await _PatientsService.DeletePatientAsync(dni);

            return patient;
        }

        // // PUT: api/Patients/5
        /// <summary>
        /// Modifica los datos de un paciente
        ///     - 
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{dni}")]
        public async Task<IActionResult> PutPatient(int dni, [FromBody] PatientUpdateDTO request)
        {

            if (dni != request.DNI)
            {
                return BadRequest();
            }

            var patientUpdate = _mapper.Map<PatientUpdateDTO, Patient>(request);
            await _PatientsService.ModifyPatientAsync(patientUpdate);

            var patientDTO = _mapper.Map<Patient, PatientDTO>(patientUpdate);

            return Ok(patientDTO);
        }
    }
}
