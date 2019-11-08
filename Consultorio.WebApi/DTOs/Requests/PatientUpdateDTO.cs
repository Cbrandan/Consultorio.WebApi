using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.DTOs.Requests
{
    public class PatientUpdateDTO
    {
        [Required]
        public int DNI { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
