using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Consultorio.WebApi.Data.Constants;

namespace Consultorio.WebApi.Models
{
    public class Patient : Person
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime? HighDate { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}