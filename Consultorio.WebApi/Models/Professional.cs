using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.Models
{
    public class Professional : Person
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int License { get; set; }
        [Required]
        public virtual Specialty Speciality { get; set; }
    }
}
