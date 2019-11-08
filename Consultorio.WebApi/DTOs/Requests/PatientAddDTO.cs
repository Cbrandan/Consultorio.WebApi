using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.DTOs.Requests
{
    public class PatientAddDTO
    {
        [Required]
        public int DNI { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
