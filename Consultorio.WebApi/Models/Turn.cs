using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.Models
{
    public class Turn
    {
        public Guid Id { get; set; }
        [Required]
        public virtual Patient IdPatient { get; set; }
        [Required]
        public virtual Specialty IdSpecialty { get; set; }
        [Required]
        public virtual Professional IdProfessional { get; set; }
        [Required]
        public DateTime TurnDate { get; set; }
        public string Note { get; set; }
        public bool MarkDone { get; set; }
    }
}
