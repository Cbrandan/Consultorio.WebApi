using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Consultorio.WebApi.Data.Constants;

namespace Consultorio.WebApi.Models
{
    public class Person
    {
        [Required]
        [Key]
        public int DNI { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Sexo Sex { get; set; }
    }
}
