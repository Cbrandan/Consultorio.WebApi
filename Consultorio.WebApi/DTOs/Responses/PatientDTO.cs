using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.DTOs.Responses
{
    public class PatientDTO
    {
        public int DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
